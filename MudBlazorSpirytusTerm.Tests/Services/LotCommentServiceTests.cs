using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

/// <summary>
/// LotCommentService のユニットテスト。
/// </summary>
public class LotCommentServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotCommentService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotCommentService>());

    // ──────── SetCommentAsync 正常系 ────────

    [Fact]
    public async Task SetCommentAsync_Success_ReturnsSuccessWithLastUpdate()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotLastUpdate, "20250415120000");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotChgComm, response);
        var svc = CreateService(mock);

        var result = await svc.SetCommentAsync(
            lotId: "LOT001",
            comments: "テストコメント",
            lotLastUpdate: "20250415100000");

        Assert.True(result.IsSuccess);
        Assert.Equal("20250415120000", result.LotLastUpdate);
        Assert.Equal("", result.ErrorMessage);
    }

    [Fact]
    public async Task SetCommentAsync_SendsCorrectTags()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.LotLastUpdate, "20250415120000"));

        var mock = TestHelper.CreateMock(MsgIds.LotChgComm, response);
        var svc = CreateService(mock);

        await svc.SetCommentAsync(
            lotId: "LOT001",
            comments: "コメント内容",
            lotLastUpdate: "20250415100000",
            empId: "EMP999");

        mock.Verify(m => m.SendMessageAsync(
            MsgIds.LotChgComm,
            It.Is<string>(s =>
                s.Contains("LOT001") &&
                s.Contains("EMP999") &&
                s.Contains("MSG_VER")),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    // ──────── SetCommentAsync 異常系 ────────

    [Fact]
    public async Task SetCommentAsync_ErrorResponse_ReturnsFailureWithMessage()
    {
        var response = TestHelper.BuildErrorResponse("コメント登録に失敗しました。");
        var mock = TestHelper.CreateMock(MsgIds.LotChgComm, response);
        var svc = CreateService(mock);

        var result = await svc.SetCommentAsync(
            lotId: "LOT001",
            comments: "テストコメント",
            lotLastUpdate: "20250415100000");

        Assert.False(result.IsSuccess);
        Assert.Contains("コメント登録に失敗しました", result.ErrorMessage);
    }

    [Fact]
    public async Task SetCommentAsync_ErrorResponse_NoErrMsg_ReturnsFallbackMessage()
    {
        // RET="1" だが ERR_MSG が空の応答
        var msg = new TfMsg();
        msg.AddString(Tags.Ret, Tags.False);
        var response = msg.ToTfString();

        var mock = TestHelper.CreateMock(MsgIds.LotChgComm, response);
        var svc = CreateService(mock);

        var result = await svc.SetCommentAsync(
            lotId: "LOT001",
            comments: "テスト",
            lotLastUpdate: "20250415100000");

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.ErrorMessage);
    }

    [Fact]
    public async Task SetCommentAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotChgComm, new TimeoutException("タイムアウト"));
        var svc = CreateService(mock);

        var result = await svc.SetCommentAsync(
            lotId: "LOT001",
            comments: "テスト",
            lotLastUpdate: "20250415100000");

        Assert.False(result.IsSuccess);
        Assert.Contains("通信エラー", result.ErrorMessage);
    }

    [Fact]
    public async Task SetCommentAsync_InvalidResponse_ReturnsFailure()
    {
        // TfMsg 形式でない応答
        var mock = TestHelper.CreateMock(MsgIds.LotChgComm, "INVALID_RESPONSE");
        var svc = CreateService(mock);

        var result = await svc.SetCommentAsync(
            lotId: "LOT001",
            comments: "テスト",
            lotLastUpdate: "20250415100000");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task SetCommentAsync_EmptyResponse_ReturnsFailure()
    {
        var mock = TestHelper.CreateMock(MsgIds.LotChgComm, "");
        var svc = CreateService(mock);

        var result = await svc.SetCommentAsync(
            lotId: "LOT001",
            comments: "テスト",
            lotLastUpdate: "20250415100000");

        Assert.False(result.IsSuccess);
        Assert.Contains("空の応答", result.ErrorMessage);
    }
}
