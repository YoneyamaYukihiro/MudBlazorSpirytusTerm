using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotStepBackServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotStepBackService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotStepBackService>());

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
            msg.AddString(Tags.NowSt,         "1");
            msg.AddString(Tags.WfNum,         "25");
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

    // ──────── GetOpStepListAsync ────────

    [Fact]
    public async Task GetOpStepListAsync_Success_ReturnsOpList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var opAry = new TfMsgAry();
            var opMsg = new TfMsg();
            opMsg.AddString(Tags.OpId, "OP01");
            var stepAry = new TfMsgAry();
            var stepMsg = new TfMsg();
            stepMsg.AddString(Tags.StepId, "ST01");
            stepAry.Add(stepMsg);
            opMsg.AddMsgAry(Tags.StepList, stepAry);
            opAry.Add(opMsg);
            msg.AddMsgAry(Tags.OpList, opAry);
        });

        var mock = TestHelper.CreateMock("mnt_.opsteplist", response);
        var svc  = CreateService(mock);

        var result = await svc.GetOpStepListAsync("LOT001");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.OpList);
        Assert.Single(result.OpList);
        Assert.Equal("OP01", result.OpList[0].OpId);
        Assert.Single(result.OpList[0].StepList);
        Assert.Equal("ST01", result.OpList[0].StepList[0].StepId);
    }

    [Fact]
    public async Task GetOpStepListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("工程情報取得エラー");
        var mock = TestHelper.CreateMock("mnt_.opsteplist", response);
        var svc  = CreateService(mock);

        var result = await svc.GetOpStepListAsync("LOT001");

        Assert.False(result.IsSuccess);
    }

    // ──────── GetEventHistAsync ────────

    [Fact]
    public async Task GetEventHistAsync_Success_ReturnsEvents()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId,         "LOT001");
            msg.AddString(Tags.LotLastUpdate, "20250415100000");
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.OpId,    "OP01");
            e.AddString(Tags.StepId,  "ST01");
            e.AddString("LOT_EVENT_ID",  "EVT001");
            e.AddString("EVENT_NAME",    "工程完了");
            e.AddString(Tags.EntryTime,  "20250415100000");
            e.AddString(Tags.EmpId,      "EMP001");
            e.AddString(Tags.EmpName,    "山田太郎");
            e.AddString(Tags.Comments,   "");
            e.AddString("DELETE_PROHIBITED", "0");
            ary.Add(e);
            msg.AddMsgAry("EVENT_LIST", ary);
        });

        var mock = TestHelper.CreateMock("mnt_.eventhist", response);
        var svc  = CreateService(mock);

        var result = await svc.GetEventHistAsync("LOT001", "OP01", "ST01");

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001", result.LotId);
        Assert.NotNull(result.EventList);
        Assert.Single(result.EventList);
        Assert.Equal("OP01", result.EventList[0].OpId);
    }

    [Fact]
    public async Task GetEventHistAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("イベント履歴取得エラー");
        var mock = TestHelper.CreateMock("mnt_.eventhist", response);
        var svc  = CreateService(mock);

        var result = await svc.GetEventHistAsync("LOT001", "OP01", "ST01");

        Assert.False(result.IsSuccess);
    }

    // ──────── ExecuteStepBackAsync ────────

    [Fact]
    public async Task ExecuteStepBackAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock("mnt_.delhist_", response);
        var svc  = CreateService(mock);

        var result = await svc.ExecuteStepBackAsync(
            "LOT001", "OP01", "ST01", "EMP001", "20250415100000");

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task ExecuteStepBackAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("工程戻しエラー");
        var mock = TestHelper.CreateMock("mnt_.delhist_", response);
        var svc  = CreateService(mock);

        var result = await svc.ExecuteStepBackAsync(
            "LOT001", "OP01", "ST01", "EMP001", "20250415100000");

        Assert.False(result.IsSuccess);
        Assert.Contains("工程戻しエラー", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteStepBackAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows("mnt_.delhist_", new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.ExecuteStepBackAsync(
            "LOT001", "OP01", "ST01", "EMP001", "20250415100000");

        Assert.False(result.IsSuccess);
    }
}
