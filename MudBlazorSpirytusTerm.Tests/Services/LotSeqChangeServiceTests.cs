using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotSeqChangeServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotSeqChangeService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotSeqChangeService>());

    // ──────── GetWaitingLotListAsync ────────

    [Fact]
    public async Task GetWaitingLotListAsync_Success_ReturnsItems()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.WpTypeFlag, "0");
            msg.AddString(Tags.McType,     "1");
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.LotId,         "LOT001");
            e.AddString(Tags.CarrierId,     "CRR001");
            e.AddString(Tags.SeqNum,        "1");
            e.AddString(Tags.LotLastUpdate, "20250415100000");
            e.AddString(Tags.FlowClass,     "1");
            e.AddString(Tags.LotPriority,   "1");
            e.AddString(Tags.OpId,          "OP01");
            e.AddString(Tags.StepId,        "ST01");
            e.AddString(Tags.RecipeId,      "RCP001");
            e.AddString(Tags.DispatchStartTime,   "");
            e.AddString(Tags.EngEmpName,    "山田太郎");
            e.AddString(Tags.NowSt,         "1");
            e.AddString(Tags.WfNum,         "25");
            e.AddString(Tags.ChipQuantity,  "500");
            e.AddString(Tags.CurrentPositionName, "");
            e.AddString(Tags.CarrierStatId, "");
            e.AddString(Tags.DestName,      "");
            e.AddString(Tags.LotCommentsFlag, "0");
            e.AddString(Tags.AvailableRecipeFlag, "1");
            e.AddString(Tags.ShipDiffDay,   "0");
            e.AddString(Tags.FrRecipeFlag,  "0");
            e.AddString(Tags.GrbClass,      "1");
            e.AddString(Tags.LotHoldFlag,   "0");
            e.AddString(Tags.LotStopFlag,   "0");
            e.AddString(Tags.ReworkFlag,    "0");
            e.AddString(Tags.LimitTime,     "");
            e.AddString(Tags.LcDirection,   "");
            ary.Add(e);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetWaitingLotListAsync("1AFP310CTS01");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Items);
        Assert.Single(result.Items);
        Assert.Equal("LOT001", result.Items[0].LotId);
        Assert.Equal("1",      result.Items[0].SeqNum);
    }

    [Fact]
    public async Task GetWaitingLotListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("一覧取得エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetWaitingLotListAsync("1AFP310CTS01");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetWaitingLotListAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotList, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.GetWaitingLotListAsync("1AFP310CTS01");

        Assert.False(result.IsSuccess);
    }

    // ──────── ChangeSeqNumAsync ────────

    [Fact]
    public async Task ChangeSeqNumAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotChgSeqNum, response);
        var svc  = CreateService(mock);

        var items = new[]
        {
            new LotSeqChangeService.ChangeItem("LOT001", "1", "OP01", "ST01", "20250415100000", "1")
        };
        var result = await svc.ChangeSeqNumAsync("1AFP310CTS01", items);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task ChangeSeqNumAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("処理順変更エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotChgSeqNum, response);
        var svc  = CreateService(mock);

        var result = await svc.ChangeSeqNumAsync("1AFP310CTS01", []);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task ChangeSeqNumAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotChgSeqNum, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.ChangeSeqNumAsync("1AFP310CTS01", []);

        Assert.False(result.IsSuccess);
    }
}
