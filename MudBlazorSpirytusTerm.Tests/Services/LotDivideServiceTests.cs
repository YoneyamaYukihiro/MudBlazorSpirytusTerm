using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotDivideServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotDivideService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotDivideService>());

    // ──────── GetCarrierStateAsync ────────

    [Fact]
    public async Task GetCarrierStateAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId,         "LOT001");
            msg.AddString(Tags.PdId,          "PD01");
            msg.AddString(Tags.WfNum,         "25");
            msg.AddString(Tags.LotLastUpdate, "20250415100000");
        });

        var mock = TestHelper.CreateMock(MsgIds.CarrCurState, response);
        var svc  = CreateService(mock);

        var result = await svc.GetCarrierStateAsync("CRR001");

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001", result.LotId);
    }

    [Fact]
    public async Task GetCarrierStateAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("キャリア照合エラー");
        var mock = TestHelper.CreateMock(MsgIds.CarrCurState, response);
        var svc  = CreateService(mock);

        var result = await svc.GetCarrierStateAsync("CRR001");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetCarrierStateAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.CarrCurState, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.GetCarrierStateAsync("CRR001");

        Assert.False(result.IsSuccess);
    }

    // ──────── ExecuteAsync ────────

    [Fact]
    public async Task ExecuteAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.Msg,     "分割完了");
            msg.AddString(Tags.MsgCode, "0001");
        });

        var mock = TestHelper.CreateMock("lot_.divide__", response);
        var svc  = CreateService(mock);

        var req = new LotDivideService.DivideRequest(
            LotId:         "LOT001",
            GrbClass:      "1",
            DivideLotId:   "LOT002",
            DivideGrbClass: "1",
            Comments:      "",
            EmpId:         "EMP001",
            LotLastUpdate: "20250415100000",
            DivideWfMapList: []);
        var result = await svc.ExecuteAsync(req);

        Assert.True(result.IsSuccess);
        Assert.Equal("分割完了", result.GuidMsg);
    }

    [Fact]
    public async Task ExecuteAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("ロット分割エラー");
        var mock = TestHelper.CreateMock("lot_.divide__", response);
        var svc  = CreateService(mock);

        var req = new LotDivideService.DivideRequest(
            "LOT001", "1", "LOT002", "1", "", "EMP001", "20250415100000", []);
        var result = await svc.ExecuteAsync(req);

        Assert.False(result.IsSuccess);
        Assert.Contains("ロット分割エラー", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows("lot_.divide__", new TimeoutException());
        var svc  = CreateService(mock);

        var req = new LotDivideService.DivideRequest(
            "LOT001", "1", "LOT002", "1", "", "EMP001", "20250415100000", []);
        var result = await svc.ExecuteAsync(req);

        Assert.False(result.IsSuccess);
    }
}
