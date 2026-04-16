using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotOutServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotOutService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotOutService>());

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
            msg.AddString(Tags.FlowClass,     "1");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc  = CreateService(mock);

        var result = await svc.GetLotInfoAsync("CRR001");

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001", result.LotId);
        Assert.Equal("OP01",   result.OpId);
        Assert.Equal("PD01",   result.PdId);
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

    // ──────── ExecuteTerminateAsync ────────

    [Fact]
    public async Task ExecuteTerminateAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock("lot_.terminate", response);
        var svc  = CreateService(mock);

        var result = await svc.ExecuteTerminateAsync(
            lotId:             "LOT001",
            endClass:          "3",
            reasonCode:        "RC01",
            responsibleEmpId:  "EMP001",
            empId:             "EMP001",
            lotLastUpdate:     "20250415100000");

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task ExecuteTerminateAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("ロット終了エラー");
        var mock = TestHelper.CreateMock("lot_.terminate", response);
        var svc  = CreateService(mock);

        var result = await svc.ExecuteTerminateAsync(
            "LOT001", "3", "RC01", "EMP001", "EMP001", "20250415100000");

        Assert.False(result.IsSuccess);
        Assert.Contains("ロット終了エラー", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteTerminateAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows("lot_.terminate", new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.ExecuteTerminateAsync(
            "LOT001", "3", "RC01", "EMP001", "EMP001", "20250415100000");

        Assert.False(result.IsSuccess);
    }
}
