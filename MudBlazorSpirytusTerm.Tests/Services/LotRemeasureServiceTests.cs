using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotRemeasureServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotRemeasureService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotRemeasureService>());

    // ──────── GetLotInfoAsync ────────

    [Fact]
    public async Task GetLotInfoAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId,         "LOT001");
            msg.AddString(Tags.OpId,          "OP01");
            msg.AddString(Tags.StepId,        "ST01");
            msg.AddString(Tags.PdId,          "PD01");
            msg.AddString(Tags.PdName,        "テスト品種");
            msg.AddString(Tags.NowSt,         "1");
            msg.AddString(Tags.WfNum,         "25");
            msg.AddString(Tags.EngEmpName,    "山田太郎");
            msg.AddString(Tags.LotLastUpdate, "20250415100000");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc  = CreateService(mock);

        var result = await svc.GetLotInfoAsync("CRR001");

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001", result.LotId);
        Assert.Equal("OP01",   result.OpId);
    }

    [Fact]
    public async Task GetLotInfoAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("ロット情報取得エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc  = CreateService(mock);

        var result = await svc.GetLotInfoAsync("CRR001");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetLotInfoAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotCurState, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.GetLotInfoAsync("CRR001");

        Assert.False(result.IsSuccess);
    }

    // ──────── ExecuteRemeasureAsync ────────

    [Fact]
    public async Task ExecuteRemeasureAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.Msg,     "再測定登録完了");
            msg.AddString(Tags.MsgCode, "0001");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotStepRestart, response);
        var svc  = CreateService(mock);

        var result = await svc.ExecuteRemeasureAsync("LOT001", "EMP001", "20250415100000");

        Assert.True(result.IsSuccess);
        Assert.Equal("再測定登録完了", result.GuidMsg);
    }

    [Fact]
    public async Task ExecuteRemeasureAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("再測定登録エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotStepRestart, response);
        var svc  = CreateService(mock);

        var result = await svc.ExecuteRemeasureAsync("LOT001", "EMP001", "20250415100000");

        Assert.False(result.IsSuccess);
        Assert.Contains("再測定登録エラー", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteRemeasureAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotStepRestart, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.ExecuteRemeasureAsync("LOT001", "EMP001", "20250415100000");

        Assert.False(result.IsSuccess);
    }
}
