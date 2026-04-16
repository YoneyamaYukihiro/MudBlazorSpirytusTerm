using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class TimeRestrictFlowServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private TimeRestrictFlowService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<TimeRestrictFlowService>());

    // ──────── GetRestrictStatusAsync ────────

    [Fact]
    public async Task GetRestrictStatusAsync_Success_ReturnsItems()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var flowAry = new TfMsgAry();
            var f = new TfMsg();
            f.AddString(Tags.FromOpId,   "OP01");
            f.AddString(Tags.FromStepId, "ST01");
            f.AddString(Tags.ToOpId,     "OP02");
            f.AddString(Tags.ToStepId,   "ST02");
            f.AddString(Tags.LotStopOn,  "1");
            f.AddString(Tags.EditEmpName, "山田太郎");
            f.AddString(Tags.EditTime,   "20250415100000");
            flowAry.Add(f);
            msg.AddMsgAry(Tags.RestrictFlowList, flowAry);

            var wpAry = new TfMsgAry();
            var w = new TfMsg();
            w.AddString(Tags.WpId,          "1AFP310CTS01");
            w.AddString(Tags.WpName,        "炉装置A");
            w.AddString(Tags.SeqNum,        "1");
            w.AddString(Tags.ProcessingName, "処理中");
            w.AddString(Tags.LotStopOff,    "0");
            w.AddString(Tags.WaitLotNum,    "3");
            w.AddString(Tags.EditEmpName,   "山田太郎");
            w.AddString(Tags.EditTime,      "20250415100000");
            wpAry.Add(w);
            msg.AddMsgAry(Tags.RestrictWpList, wpAry);
        });

        var mock = TestHelper.CreateMock(MsgIds.TimeRestrictStatus, response);
        var svc  = CreateService(mock);

        var result = await svc.GetRestrictStatusAsync("1");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.FlowItems);
        Assert.Single(result.FlowItems);
        Assert.Equal("OP01", result.FlowItems[0].FromOpId);
        Assert.NotNull(result.WpItems);
        Assert.Single(result.WpItems);
        Assert.Equal("1AFP310CTS01", result.WpItems[0].WpId);
    }

    [Fact]
    public async Task GetRestrictStatusAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("時間制限設定取得エラー");
        var mock = TestHelper.CreateMock(MsgIds.TimeRestrictStatus, response);
        var svc  = CreateService(mock);

        var result = await svc.GetRestrictStatusAsync("1");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetRestrictStatusAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.TimeRestrictStatus, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.GetRestrictStatusAsync("1");

        Assert.False(result.IsSuccess);
    }

    // ──────── RegistRestrictAsync ────────

    [Fact]
    public async Task RegistRestrictAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.TimeRestrictRegist, response);
        var svc  = CreateService(mock);

        var flowItems = new[]
        {
            new TimeRestrictFlowService.RegistFlowItem(
                "OP01", "ST01", "OP02", "ST02", "1", "1")
        };
        var wpItems = new[]
        {
            new TimeRestrictFlowService.RegistWpItem(
                "1AFP310CTS01", "1", "0", "3", "1")
        };
        var result = await svc.RegistRestrictAsync("EMP001", "1", flowItems, wpItems);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task RegistRestrictAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("時間制限設定変更エラー");
        var mock = TestHelper.CreateMock(MsgIds.TimeRestrictRegist, response);
        var svc  = CreateService(mock);

        var result = await svc.RegistRestrictAsync("EMP001", "1", [], []);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task RegistRestrictAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.TimeRestrictRegist, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.RegistRestrictAsync("EMP001", "1", [], []);

        Assert.False(result.IsSuccess);
    }
}
