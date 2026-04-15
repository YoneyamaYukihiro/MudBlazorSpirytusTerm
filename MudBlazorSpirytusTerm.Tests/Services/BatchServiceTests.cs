using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class BatchServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private BatchService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<BatchService>());

    // ──────── GetBatchLotListAsync ────────

    [Fact]
    public async Task GetBatchLotListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var batchAry = new TfMsgAry();
            var batch = new TfMsg();
            batch.AddString(Tags.BatchId, "BAT001");
            batch.AddString(Tags.WpId, "WP001");
            batch.AddString(Tags.WpName, "装置A");
            batch.AddString(Tags.RecipeId, "RCP01");
            batch.AddString(Tags.EqType, "CVD");
            batch.AddString(Tags.MesModeId, "MODE01");

            var lotAry = new TfMsgAry();
            var lot = new TfMsg();
            lot.AddString(Tags.LotId, "LOT001");
            lot.AddString(Tags.CarrierId, "CAR001");
            lot.AddString(Tags.FlowClass, "TFT");
            lot.AddString(Tags.OpId, "OP01");
            lot.AddString(Tags.StepId, "STEP01");
            lot.AddString(Tags.WfNum, "25");
            lot.AddString(Tags.ChipQuantity, "100");
            lot.AddString(Tags.LotPriority, "5");
            lot.AddString(Tags.LimitTime, "");
            lot.AddString(Tags.WarnTime, "");
            lot.AddString(Tags.ToOpId, "OP02");
            lot.AddString(Tags.ToStepId, "STEP02");
            lot.AddString(Tags.ReworkFlag, "0");
            lot.AddString(Tags.LotLastUpdate, "20250415100000");
            lot.AddString(Tags.CurrentPositionName, "ストッカーA");
            lot.AddString(Tags.DispatchStartTime, "20250415110000");
            lotAry.Add(lot);
            batch.AddMsgAry(Tags.BLotList, lotAry);

            batchAry.Add(batch);
            msg.AddMsgAry(Tags.BatchList, batchAry);
        });

        var mock = TestHelper.CreateMock(MsgIds.BatLotList, response);
        var svc = CreateService(mock);

        var result = await svc.GetBatchLotListAsync(
            new BatchService.BatchLotListRequest(ClassDivision: "1"));

        Assert.Single(result);
        Assert.Equal("BAT001", result[0].BatchId);
        Assert.Equal("装置A", result[0].WpName);
        Assert.Single(result[0].Lots);
        Assert.Equal("LOT001", result[0].Lots[0].LotId);
    }

    [Fact]
    public async Task GetBatchLotListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.BatLotList, response);
        var svc = CreateService(mock);

        var result = await svc.GetBatchLotListAsync(
            new BatchService.BatchLotListRequest(ClassDivision: "1"));

        Assert.Empty(result);
    }

    // ──────── BatchWorkStartAsync ────────

    [Fact]
    public async Task BatchWorkStartAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.ToOpId, "OP02");
            msg.AddString(Tags.ToStepId, "STEP02");
            msg.AddString(Tags.LimitTime, "120");
            msg.AddString(Tags.WarnTime, "60");

            var lotAry = new TfMsgAry();
            var lot = new TfMsg();
            lot.AddString(Tags.LotId, "LOT001");
            lot.AddString(Tags.LotLastUpdate, "20250415120000");
            lot.AddString(Tags.ResultFlag, "0");
            lotAry.Add(lot);
            msg.AddMsgAry(Tags.LotList, lotAry);
        });

        var mock = TestHelper.CreateMock(MsgIds.BatStartWrk, response);
        var svc = CreateService(mock);

        var lots = new[] { new BatchService.BatchLotRef("LOT001", "20250415100000") };
        var result = await svc.BatchWorkStartAsync(
            new BatchService.BatchWorkStartRequest(BatchId: "BAT001", EmpId: "EMP001",
                EqType: "CVD", Lots: lots));

        Assert.True(result.IsSuccess);
        Assert.Equal("OP02", result.ToOpId);
    }

    [Fact]
    public async Task BatchWorkStartAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("バッチ作業開始失敗");
        var mock = TestHelper.CreateMock(MsgIds.BatStartWrk, response);
        var svc = CreateService(mock);

        var lots = new[] { new BatchService.BatchLotRef("LOT001", "20250415100000") };
        var result = await svc.BatchWorkStartAsync(
            new BatchService.BatchWorkStartRequest(BatchId: "BAT001", EmpId: "EMP001",
                EqType: "CVD", Lots: lots));

        Assert.False(result.IsSuccess);
        Assert.Contains("バッチ作業開始失敗", result.ErrorMessage);
    }

    // ──────── BatchProcessStartAsync / EndAsync ────────

    [Fact]
    public async Task BatchProcessStartAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.BatPrcStart, response);
        var svc = CreateService(mock);

        var lots = new[] { new BatchService.BatchLotRef("LOT001", "20250415100000") };
        var result = await svc.BatchProcessStartAsync(
            new BatchService.BatchProcessRequest(BatchId: "BAT001", EmpId: "EMP001",
                EqType: "CVD", Lots: lots));

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task BatchProcessEndAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.BatPrcEnd, response);
        var svc = CreateService(mock);

        var lots = new[] { new BatchService.BatchLotRef("LOT001", "20250415100000") };
        var result = await svc.BatchProcessEndAsync(
            new BatchService.BatchProcessRequest(BatchId: "BAT001", EmpId: "EMP001",
                EqType: "CVD", Lots: lots));

        Assert.True(result.IsSuccess);
    }

    // ──────── BatchWorkEndAsync ────────

    [Fact]
    public async Task BatchWorkEndAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.Msg, "ガイダンスメッセージ");
            msg.AddString(Tags.MsgCode, "G001");
        });

        var mock = TestHelper.CreateMock(MsgIds.BatEndWrk, response);
        var svc = CreateService(mock);

        var lots = new[] { new BatchService.BatchLotRef("LOT001", "20250415100000") };
        var result = await svc.BatchWorkEndAsync(
            new BatchService.BatchWorkEndRequest(BatchId: "BAT001", EmpId: "EMP001",
                EqType: "CVD", Lots: lots));

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task BatchWorkEndAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.BatEndWrk, new TimeoutException());
        var svc = CreateService(mock);

        var lots = new[] { new BatchService.BatchLotRef("LOT001", "20250415100000") };
        var result = await svc.BatchWorkEndAsync(
            new BatchService.BatchWorkEndRequest(BatchId: "BAT001", EmpId: "EMP001",
                EqType: "CVD", Lots: lots));

        Assert.False(result.IsSuccess);
    }
}
