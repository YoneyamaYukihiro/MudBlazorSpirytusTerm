using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class BatchManagementServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private BatchManagementService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<BatchManagementService>());

    // ──────── GetBatchMcGroupListAsync ────────

    [Fact]
    public async Task GetBatchMcGroupListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var g = new TfMsg();
            g.AddString(Tags.McGroupId, "GRP01");
            g.AddString(Tags.McGroupName, "バッチグループA");
            ary.Add(g);
            msg.AddMsgAry(Tags.McGroupList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasMcGroupList, response);
        var svc = CreateService(mock);

        var result = await svc.GetBatchMcGroupListAsync();

        Assert.Single(result);
        Assert.Equal("GRP01", result[0].Id);
    }

    [Fact]
    public async Task GetBatchMcGroupListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasMcGroupList, response);
        var svc = CreateService(mock);

        var result = await svc.GetBatchMcGroupListAsync();

        Assert.Empty(result);
    }

    // ──────── GetWpListAsync ────────

    [Fact]
    public async Task GetWpListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var wp = new TfMsg();
            wp.AddString(Tags.WpId, "WP001");
            wp.AddString(Tags.WpName, "装置A");
            wp.AddString(Tags.MesModeId, "MODE01");
            wp.AddString(Tags.EqType, "CVD");
            ary.Add(wp);
            msg.AddMsgAry(Tags.WpList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasWpList, response);
        var svc = CreateService(mock);

        var result = await svc.GetWpListAsync("GRP01");

        Assert.Single(result);
        Assert.Equal("WP001", result[0].WpId);
        Assert.Equal("CVD", result[0].EqType);
    }

    // ──────── GetComposeStatusAsync ────────

    [Fact]
    public async Task GetComposeStatusAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.WpId, "WP001");
            msg.AddString(Tags.BatchComposeType, "1");
            msg.AddString(Tags.EditEmpName, "山田");
            msg.AddString(Tags.EditTime, "20250415100000");
            msg.AddMsgAry(Tags.RecipeList, new TfMsgAry());
        });

        var mock = TestHelper.CreateMock(MsgIds.BatComposeStatus, response);
        var svc = CreateService(mock);

        var result = await svc.GetComposeStatusAsync("WP001");

        Assert.True(result.IsSuccess);
        Assert.Equal("WP001", result.WpId);
    }

    [Fact]
    public async Task GetComposeStatusAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("ステータス取得失敗");
        var mock = TestHelper.CreateMock(MsgIds.BatComposeStatus, response);
        var svc = CreateService(mock);

        var result = await svc.GetComposeStatusAsync("WP001");

        Assert.False(result.IsSuccess);
    }

    // ──────── GetWaitingLotListAsync ────────

    [Fact]
    public async Task GetWaitingLotListAsync_Success_ReturnsLots()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var lot = new TfMsg();
            lot.AddString(Tags.LotId, "LOT001");
            lot.AddString(Tags.RecipeId, "RCP01");
            lot.AddString(Tags.FlowClass, "TFT");
            lot.AddString(Tags.LotPriority, "5");
            lot.AddString(Tags.OpId, "OP01");
            lot.AddString(Tags.StepId, "STEP01");
            lot.AddString(Tags.CarrierId, "CAR001");
            lot.AddString(Tags.WfQuantity, "25");
            lot.AddString(Tags.CurrentPositionName, "ストッカーA");
            lot.AddString(Tags.LotStopFlag, "0");
            lot.AddString(Tags.LotHoldFlag, "0");
            lot.AddString(Tags.WaitTimeH, "2");
            ary.Add(lot);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.BatWaitingLotList, response);
        var svc = CreateService(mock);

        var result = await svc.GetWaitingLotListAsync("WP001");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Lots);
        Assert.Single(result.Lots);
        Assert.Equal("LOT001", result.Lots[0].LotId);
    }

    // ──────── RegisterComposeAsync ────────

    [Fact]
    public async Task RegisterComposeAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.BatComposeRegist, response);
        var svc = CreateService(mock);

        var result = await svc.RegisterComposeAsync(
            new BatchManagementService.ComposeRegistRequest(
                WpId: "WP001", EmpId: "EMP001", BatchComposeType: "1",
                EditFlag: "0", RecipeList: Array.Empty<BatchManagementService.RecipeRow>()));

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task RegisterComposeAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("登録失敗");
        var mock = TestHelper.CreateMock(MsgIds.BatComposeRegist, response);
        var svc = CreateService(mock);

        var result = await svc.RegisterComposeAsync(
            new BatchManagementService.ComposeRegistRequest(
                WpId: "WP001", EmpId: "EMP001", BatchComposeType: "1",
                EditFlag: "0", RecipeList: Array.Empty<BatchManagementService.RecipeRow>()));

        Assert.False(result.IsSuccess);
    }
}
