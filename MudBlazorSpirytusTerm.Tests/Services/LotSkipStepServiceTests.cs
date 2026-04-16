using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotSkipStepServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotSkipStepService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotSkipStepService>());

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
            msg.AddMsgAry(Tags.StepList, new TfMsgAry());
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

    // ──────── GetNextStepsAsync ────────

    [Fact]
    public async Task GetNextStepsAsync_Success_ReturnsSteps()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.NextOpId,    "OP02");
            e.AddString(Tags.NextStepId,  "ST02");
            e.AddString(Tags.StepDivision, "1");
            e.AddMsgAry(Tags.WpList, new TfMsgAry());
            ary.Add(e);
            msg.AddMsgAry(Tags.NextStepList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotNextStepList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetNextStepsAsync("LOT001", "OP01", "ST01");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.StepList);
        Assert.Single(result.StepList);
        Assert.Equal("OP02", result.StepList[0].NextOpId);
    }

    [Fact]
    public async Task GetNextStepsAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("次工程取得エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotNextStepList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetNextStepsAsync("LOT001", "OP01", "ST01");

        Assert.False(result.IsSuccess);
    }

    // ──────── CheckSkipAsync ────────

    [Fact]
    public async Task CheckSkipAsync_Success_ReturnsOk()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.Result, "0");
            msg.AddString(Tags.OpId,   "OP01");
            msg.AddString(Tags.StepId, "ST01");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotChkSkipStep, response);
        var svc  = CreateService(mock);

        var result = await svc.CheckSkipAsync("CRR001");

        Assert.True(result.IsSuccess);
        Assert.Equal("0", result.Result);
    }

    [Fact]
    public async Task CheckSkipAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("スキップ可否チェックエラー");
        var mock = TestHelper.CreateMock(MsgIds.LotChkSkipStep, response);
        var svc  = CreateService(mock);

        var result = await svc.CheckSkipAsync("CRR001");

        Assert.False(result.IsSuccess);
    }

    // ──────── GetRestrictAsync ────────

    [Fact]
    public async Task GetRestrictAsync_Success_ReturnsRestrict()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.RestrictTypeId, "1");
            msg.AddString(Tags.LimitTime,      "20250415180000");
            msg.AddString(Tags.WarnTime,       "20250415170000");
            msg.AddString(Tags.FromOpId,       "OP01");
            msg.AddString(Tags.FromStepId,     "ST01");
            msg.AddString(Tags.ToOpId,         "OP02");
            msg.AddString(Tags.ToStepId,       "ST02");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotGetRestrict, response);
        var svc  = CreateService(mock);

        var result = await svc.GetRestrictAsync("LOT001");

        Assert.True(result.IsSuccess);
        Assert.Equal("1",    result.RestrictTypeId);
        Assert.Equal("OP01", result.FromOpId);
    }

    [Fact]
    public async Task GetRestrictAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("時間制限取得エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotGetRestrict, response);
        var svc  = CreateService(mock);

        var result = await svc.GetRestrictAsync("LOT001");

        Assert.False(result.IsSuccess);
    }

    // ──────── ExecuteSkipAsync ────────

    [Fact]
    public async Task ExecuteSkipAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.ActionFlag, "0");
            msg.AddString(Tags.SendResult, "");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotSkipStep, response);
        var svc  = CreateService(mock);

        var result = await svc.ExecuteSkipAsync(
            "LOT001", "OP02", "ST02", "20250415100000", "EMP001");

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task ExecuteSkipAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("工程スキップエラー");
        var mock = TestHelper.CreateMock(MsgIds.LotSkipStep, response);
        var svc  = CreateService(mock);

        var result = await svc.ExecuteSkipAsync(
            "LOT001", "OP02", "ST02", "20250415100000", "EMP001");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task ExecuteSkipAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotSkipStep, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.ExecuteSkipAsync(
            "LOT001", "OP02", "ST02", "20250415100000", "EMP001");

        Assert.False(result.IsSuccess);
    }
}
