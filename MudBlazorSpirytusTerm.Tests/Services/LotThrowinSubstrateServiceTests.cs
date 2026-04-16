using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotThrowinSubstrateServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotThrowinSubstrateService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotThrowinSubstrateService>());

    // ──────── GetCarrierStateAsync ────────

    [Fact]
    public async Task GetCarrierStateAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId,         "LOT001");
            msg.AddString(Tags.PdId,          "PD01");
            msg.AddString(Tags.PdName,        "テスト品種");
            msg.AddString(Tags.NowSt,         "1");
            msg.AddString(Tags.WfNum,         "25");
            msg.AddString(Tags.LotLastUpdate, "20250415100000");
            msg.AddString(Tags.SlotSize,      "25");
        });

        var mock = TestHelper.CreateMock("carr.curstate", response);
        var svc  = CreateService(mock);

        var result = await svc.GetCarrierStateAsync("CRR001");

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001", result.LotId);
        Assert.Equal("PD01",   result.PdId);
    }

    [Fact]
    public async Task GetCarrierStateAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("キャリア照合エラー");
        var mock = TestHelper.CreateMock("carr.curstate", response);
        var svc  = CreateService(mock);

        var result = await svc.GetCarrierStateAsync("CRR001");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetCarrierStateAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows("carr.curstate", new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.GetCarrierStateAsync("CRR001");

        Assert.False(result.IsSuccess);
    }

    // ──────── GetPriorityListAsync ────────

    [Fact]
    public async Task GetPriorityListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString("PRIORITY_ID",   "1");
            e.AddString("PRIORITY_NAME", "急急");
            ary.Add(e);
            msg.AddMsgAry("PRIORITY_LIST", ary);
        });

        var mock = TestHelper.CreateMock("mas_.priolist", response);
        var svc  = CreateService(mock);

        var result = await svc.GetPriorityListAsync();

        Assert.Single(result);
        Assert.Equal("1",   result[0].PriorityId);
        Assert.Equal("急急", result[0].PriorityName);
    }

    [Fact]
    public async Task GetPriorityListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock("mas_.priolist", response);
        var svc  = CreateService(mock);

        var result = await svc.GetPriorityListAsync();

        Assert.Empty(result);
    }

    // ──────── GetWpListAsync ────────

    [Fact]
    public async Task GetWpListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.WpId,   "1AFP310CTS01");
            e.AddString(Tags.WpName, "炉装置A");
            ary.Add(e);
            msg.AddMsgAry(Tags.WpList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasWpList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetWpListAsync();

        Assert.Single(result);
        Assert.Equal("1AFP310CTS01", result[0].WpId);
        Assert.Equal("炉装置A",       result[0].WpName);
    }

    [Fact]
    public async Task GetWpListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasWpList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetWpListAsync();

        Assert.Empty(result);
    }

    // ──────── ExecuteAsync ────────

    [Fact]
    public async Task ExecuteAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.Msg,     "投入完了");
            msg.AddString(Tags.MsgCode, "0001");
        });

        var mock = TestHelper.CreateMock("lot_.throwin_", response);
        var svc  = CreateService(mock);

        var req = new LotThrowinSubstrateService.ThrowinRequest(
            LotId:       "LOT001",
            CarrierId:   "CRR001",
            EmpId:       "EMP001",
            LotPriority: "1",
            OnlineFlag:  "0",
            WpId:        "1AFP310CTS01",
            WfMapList:   []);
        var result = await svc.ExecuteAsync(req);

        Assert.True(result.IsSuccess);
        Assert.Equal("投入完了", result.GuidMsg);
    }

    [Fact]
    public async Task ExecuteAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("投入処理エラー");
        var mock = TestHelper.CreateMock("lot_.throwin_", response);
        var svc  = CreateService(mock);

        var req = new LotThrowinSubstrateService.ThrowinRequest(
            "LOT001", "CRR001", "EMP001", "1", "0", "1AFP310CTS01", []);
        var result = await svc.ExecuteAsync(req);

        Assert.False(result.IsSuccess);
        Assert.Contains("投入処理エラー", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows("lot_.throwin_", new TimeoutException());
        var svc  = CreateService(mock);

        var req = new LotThrowinSubstrateService.ThrowinRequest(
            "LOT001", "CRR001", "EMP001", "1", "0", "1AFP310CTS01", []);
        var result = await svc.ExecuteAsync(req);

        Assert.False(result.IsSuccess);
    }
}
