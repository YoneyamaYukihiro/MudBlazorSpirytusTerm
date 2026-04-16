using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class WfChipStatusChangeServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private WfChipStatusChangeService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<WfChipStatusChangeService>());

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
            msg.AddString(Tags.LotLastUpdate, "20250415100000");
            msg.AddString(Tags.LotScrapSetId, "SET01");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc  = CreateService(mock);

        var result = await svc.GetLotInfoAsync("CRR001", isChipMode: false);

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001", result.LotId);
        Assert.Equal("OP01",   result.OpId);
        Assert.Equal("SET01",  result.LotScrapSetId);
    }

    [Fact]
    public async Task GetLotInfoAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("ロット情報取得エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc  = CreateService(mock);

        var result = await svc.GetLotInfoAsync("CRR001", isChipMode: false);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetLotInfoAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotCurState, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.GetLotInfoAsync("CRR001", isChipMode: false);

        Assert.False(result.IsSuccess);
    }

    // ──────── GetWaferListAsync ────────

    [Fact]
    public async Task GetWaferListAsync_Success_ReturnsWfList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId,   "LOT001");
            msg.AddString(Tags.OpId,    "OP01");
            msg.AddString(Tags.StepId,  "ST01");
            msg.AddString(Tags.SlotSize, "25");
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.WfId,         "WF001");
            e.AddString(Tags.SlotPosition, "1");
            e.AddString(Tags.GrbClass,     "1");
            e.AddString(Tags.Class,        "1");
            e.AddString(Tags.ClassId,      "");
            e.AddString(Tags.WfStatusName, "良品");
            e.AddString(Tags.Result,       "");
            ary.Add(e);
            msg.AddMsgAry(Tags.WfList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotWaferList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetWaferListAsync("CRR001");

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001", result.LotId);
        Assert.NotNull(result.WfList);
        Assert.Single(result.WfList);
        Assert.Equal("WF001", result.WfList[0].WfId);
    }

    [Fact]
    public async Task GetWaferListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("WF情報取得エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotWaferList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetWaferListAsync("CRR001");

        Assert.False(result.IsSuccess);
    }

    // ──────── GetScpListAsync ────────

    [Fact]
    public async Task GetScpListAsync_Success_ReturnsItems()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.ScrapItemId,   "SCP001");
            e.AddString(Tags.ScrapItemName, "割れ");
            e.AddString(Tags.SeqNum,        "1");
            ary.Add(e);
            msg.AddMsgAry(Tags.ScrapList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasScpList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetScpListAsync("SET01", isChipMode: false);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Items);
        Assert.Single(result.Items);
        Assert.Equal("SCP001", result.Items[0].ItemId);
        Assert.Equal("割れ",   result.Items[0].ItemName);
    }

    [Fact]
    public async Task GetScpListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("不良項目取得エラー");
        var mock = TestHelper.CreateMock(MsgIds.MasScpList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetScpListAsync("SET01", isChipMode: false);

        Assert.False(result.IsSuccess);
    }

    // ──────── ExecuteInsprstAsync ────────

    [Fact]
    public async Task ExecuteInsprstAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.Result,        "0");
            msg.AddString(Tags.LotLastUpdate, "20250415110000");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotInsprst, response);
        var svc  = CreateService(mock);

        var wfEntries = new[]
        {
            new WfChipStatusChangeService.WfInputEntry(
                WfId:               "WF001",
                SlotPosition:       "1",
                Class:              WfChipStatusChangeService.ClassBad,
                ClassId:            "SCP001",
                ChipOutQuantity:    "0",
                ChipForwardQuantity: "0",
                ChipList:           [])
        };
        var result = await svc.ExecuteInsprstAsync(
            "LOT001", isChipMode: false, wfEntries, "EMP001", "20250415100000", "EMP001");

        Assert.True(result.IsSuccess);
        Assert.Equal("0", result.Result);
    }

    [Fact]
    public async Task ExecuteInsprstAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("状態変更登録エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotInsprst, response);
        var svc  = CreateService(mock);

        var result = await svc.ExecuteInsprstAsync(
            "LOT001", false, [], "EMP001", "20250415100000", "EMP001");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task ExecuteInsprstAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotInsprst, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.ExecuteInsprstAsync(
            "LOT001", false, [], "EMP001", "20250415100000", "EMP001");

        Assert.False(result.IsSuccess);
    }
}
