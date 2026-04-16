using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotDetailListServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotDetailListService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotDetailListService>());

    // ──────── GetLotDetailListAsync ────────

    [Fact]
    public async Task GetLotDetailListAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId, "LOT001");
            msg.AddString(Tags.CarrierId, "CAR001");
            msg.AddString(Tags.PdId, "PD01");
            msg.AddString(Tags.CurrentSeqNum, "5");
            msg.AddString(Tags.OpId, "OP01");
            msg.AddString(Tags.StepId, "STEP01");
            msg.AddString(Tags.NowSt, "WIP");
            msg.AddString(Tags.WfNum, "25");
            msg.AddString(Tags.HoldFlag, "0");
            msg.AddString(Tags.LastSeqNum, "10");
            msg.AddString(Tags.LotLastUpdate, "20250415120000");
            msg.AddString(Tags.LotStopFlag, "0");
            msg.AddString(Tags.SendSbId, "");
            msg.AddString(Tags.SbArea, "");
            msg.AddString(Tags.GrbClass, "A");

            var detailAry = new TfMsgAry();
            var detail = new TfMsg();
            detail.AddString(Tags.SeqNum, "1");
            detail.AddString(Tags.CarrierId, "CAR001");
            detail.AddString(Tags.OpId, "OP01");
            detail.AddString(Tags.StepId, "STEP01");
            detail.AddString(Tags.StartTime, "20250415080000");
            detail.AddString(Tags.EndTime, "20250415090000");
            detail.AddString(Tags.CollectionFlag, "0");
            detail.AddString(Tags.WfNum, "25");
            detail.AddString(Tags.ChipNum, "100");
            detail.AddString(Tags.StartEmpName, "作業者A");
            detail.AddString(Tags.EndEmpName, "作業者B");
            detail.AddString(Tags.CommentFlag, "0");
            detail.AddString(Tags.CommentTime, "");
            detail.AddString(Tags.RecipeId, "RCP01");
            detail.AddString(Tags.CdenClass, "1");
            detail.AddString(Tags.GrbClass, "A");

            var wpAry = new TfMsgAry();
            var wp = new TfMsg();
            wp.AddString(Tags.WpName, "装置A");
            wp.AddString(Tags.WpId, "WP001");
            wp.AddString(Tags.PortName, "PORT01");
            wpAry.Add(wp);
            detail.AddMsgAry(Tags.WpList, wpAry);

            detailAry.Add(detail);
            msg.AddMsgAry(Tags.DetailList, detailAry);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotDetailList, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotDetailListAsync("LOT001");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal("LOT001", result.Data!.LotId);
        Assert.Equal("5", result.Data.CurrentSeqNum);
        Assert.Single(result.Data.DetailList);
        Assert.Equal("1", result.Data.DetailList[0].SeqNum);
    }

    [Fact]
    public async Task GetLotDetailListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("テストエラー");
        var mock = TestHelper.CreateMock(MsgIds.LotDetailList, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotDetailListAsync("LOT001");

        Assert.False(result.IsSuccess);
        Assert.Contains("テストエラー", result.ErrorMessage);
    }

    [Fact]
    public async Task GetLotDetailListAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotDetailList, new Exception("接続失敗"));
        var svc = CreateService(mock);

        var result = await svc.GetLotDetailListAsync("LOT001");

        Assert.False(result.IsSuccess);
        Assert.Contains("接続失敗", result.ErrorMessage);
    }

    [Fact]
    public async Task GetLotDetailListAsync_ReplyMsgPrefixError_ExtractsMsgCodeAndMsg()
    {
        var response = TestHelper.BuildReplyMsgErrorResponse("MC0500", "キャリア[BSIA00]は存在しません。");
        var mock = TestHelper.CreateMock(MsgIds.LotDetailList, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotDetailListAsync("", "BSIA00");

        Assert.False(result.IsSuccess);
        Assert.Equal("MC0500", result.ErrorCode);
        Assert.Contains("キャリア[BSIA00]は存在しません。", result.ErrorMessage);
    }

    // ──────── GetEventCommentAsync ────────

    [Fact]
    public async Task GetEventCommentAsync_Success_ReturnsComment()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.Comments, "イベントコメント内容"));

        var mock = TestHelper.CreateMock(MsgIds.LotEventComment, response);
        var svc = CreateService(mock);

        var result = await svc.GetEventCommentAsync("LOT001", "5", "20250415100000");

        Assert.Equal("イベントコメント内容", result);
    }

    [Fact]
    public async Task GetEventCommentAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotEventComment, response);
        var svc = CreateService(mock);

        var result = await svc.GetEventCommentAsync("LOT001", "5", "20250415100000");

        Assert.Null(result);
    }

    // ──────── GetUseRecpAsync ────────

    [Fact]
    public async Task GetUseRecpAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.SelectConditionId, "COND01");
            var wpAry = new TfMsgAry();
            var wp = new TfMsg();
            wp.AddString(Tags.WpId, "WP001");
            wp.AddString(Tags.WpName, "装置A");
            wp.AddString(Tags.WfId, "WF01");
            wp.AddString(Tags.HistoryFlag, "1");

            var rcpAry = new TfMsgAry();
            var rcp = new TfMsg();
            rcp.AddString(Tags.RecipeId, "RCP01");
            rcp.AddString(Tags.DefaultFlag, "1");
            rcp.AddString(Tags.RecipeComments, "レシピコメント");
            rcp.AddMsgAry(Tags.RecipeBodyList, new TfMsgAry());
            rcpAry.Add(rcp);
            wp.AddMsgAry(Tags.RecipeList, rcpAry);

            wpAry.Add(wp);
            msg.AddMsgAry(Tags.WpList, wpAry);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotUseRecp, response);
        var svc = CreateService(mock);

        var result = await svc.GetUseRecpAsync("OP01", "STEP01", "LOT001");

        Assert.NotNull(result);
        Assert.Equal("COND01", result.SelectConditionId);
        Assert.Single(result.WpList);
    }
}
