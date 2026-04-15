using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class ProcessStepLotListServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private ProcessStepLotListService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<ProcessStepLotListService>());

    // ──────── GetOpListAsync ────────

    [Fact]
    public async Task GetOpListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var op = new TfMsg();
            op.AddString(Tags.OpId, "OP01");
            op.AddString(Tags.ValidFlag, "1");
            ary.Add(op);
            msg.AddMsgAry(Tags.OpList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasUseOpList, response);
        var svc = CreateService(mock);

        var result = await svc.GetOpListAsync();

        Assert.Single(result);
        Assert.Equal("OP01", result[0].OpId);
    }

    [Fact]
    public async Task GetOpListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasUseOpList, response);
        var svc = CreateService(mock);

        var result = await svc.GetOpListAsync();

        Assert.Empty(result);
    }

    // ──────── GetStepListAsync ────────

    [Fact]
    public async Task GetStepListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var step = new TfMsg();
            step.AddString(Tags.StepId, "STEP01");
            step.AddString(Tags.ActionFlag, "0");
            step.AddString(Tags.ValidFlag, "1");
            ary.Add(step);
            msg.AddMsgAry(Tags.StepList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotStepList, response);
        var svc = CreateService(mock);

        var result = await svc.GetStepListAsync("OP01");

        Assert.Single(result);
        Assert.Equal("STEP01", result[0].StepId);
    }

    // ──────── GetPdListAsync ────────

    [Fact]
    public async Task GetPdListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var pd = new TfMsg();
            pd.AddString(Tags.PdId, "PD01");
            pd.AddString(Tags.PdName, "テスト品種");
            pd.AddString(Tags.LcDirection, "1");
            ary.Add(pd);
            msg.AddMsgAry(Tags.PdList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasPdList, response);
        var svc = CreateService(mock);

        var result = await svc.GetPdListAsync();

        Assert.Single(result);
        Assert.Equal("PD01", result[0].PdId);
        Assert.Equal("テスト品種", result[0].PdName);
    }

    // ──────── GetFlowClassListAsync ────────

    [Fact]
    public async Task GetFlowClassListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var fc = new TfMsg();
            fc.AddString(Tags.FlowClass, "TFT");
            fc.AddString(Tags.FlowClassName, "TFT流動");
            ary.Add(fc);
            msg.AddMsgAry(Tags.FlowClassList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasFlowList, response);
        var svc = CreateService(mock);

        var result = await svc.GetFlowClassListAsync();

        Assert.Single(result);
        Assert.Equal("TFT", result[0].FlowClass);
    }

    // ──────── GetLotListAsync ────────

    [Fact]
    public async Task GetLotListAsync_Success_ReturnsResponse()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var lot = new TfMsg();
            lot.AddString(Tags.LotId, "LOT001");
            lot.AddString(Tags.CarrierId, "CAR001");
            lot.AddString(Tags.FlowClass, "TFT");
            lot.AddString(Tags.OpId, "OP01");
            lot.AddString(Tags.StepId, "STEP01");
            lot.AddString(Tags.PdId, "PD01");
            lot.AddString(Tags.NowSt, "WIP");
            lot.AddString(Tags.WfNum, "25");
            ary.Add(lot);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotOpList, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotListAsync(
            new ProcessStepLotListService.LotListRequest { OpId = "OP01" });

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.LotList);
        Assert.Single(result.LotList);
    }

    [Fact]
    public async Task GetLotListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotOpList, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotListAsync(
            new ProcessStepLotListService.LotListRequest());

        Assert.False(result.IsSuccess);
    }
}
