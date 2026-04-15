using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

/// <summary>
/// WorkService のユニットテスト。
/// GetLotCurStateAsync を中心にテストする。
/// </summary>
public class WorkServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private WorkService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<WorkService>());

    // ──────── GetLotCurStateAsync 正常系 ────────

    [Fact]
    public async Task GetLotCurStateAsync_Success_ReturnsFullResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId, "LOT001");
            msg.AddString(Tags.FlowClass, "TFT");
            msg.AddString(Tags.PdId, "PD-X100");
            msg.AddString(Tags.PdName, "テスト品種");
            msg.AddString(Tags.NowSt, "WIP");
            msg.AddString(Tags.WfNum, "25");
            msg.AddString(Tags.ChipQuantity, "100");
            msg.AddString(Tags.LotLastUpdate, "20250415120000");
            msg.AddString(Tags.EngEmpName, "山田太郎");
            msg.AddString(Tags.CarrierId, "CAR001");
            msg.AddString(Tags.LotHoldFlag, "0");
            msg.AddString(Tags.Comments, "");

            // 工程リスト
            var stepAry = new TfMsgAry();
            var step = new TfMsg();
            step.AddString(Tags.OpId, "OP01");
            step.AddString(Tags.StepId, "STEP01");
            step.AddString(Tags.StepDivision, "1");
            step.AddString(Tags.AltNumber, "");

            var wpAry = new TfMsgAry();
            var wp = new TfMsg();
            wp.AddString(Tags.WpId, "WP001");
            wp.AddString(Tags.WpName, "装置A");
            wpAry.Add(wp);
            step.AddMsgAry(Tags.WpList, wpAry);

            stepAry.Add(step);
            msg.AddMsgAry(Tags.StepList, stepAry);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotCurStateAsync("CAR001");

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001", result.LotId);
        Assert.Equal("TFT", result.FlowClass);
        Assert.Equal("PD-X100", result.PdId);
        Assert.Equal("テスト品種", result.PdName);
        Assert.Equal("WIP", result.NowSt);
        Assert.Equal("25", result.WfNum);
        Assert.Equal("20250415120000", result.LotLastUpdate);
        Assert.Equal("山田太郎", result.EngEmpName);
    }

    [Fact]
    public async Task GetLotCurStateAsync_Success_DefaultStepIsSet()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId, "LOT001");

            var stepAry = new TfMsgAry();
            var step = new TfMsg();
            step.AddString(Tags.OpId, "OP01");
            step.AddString(Tags.StepId, "STEP01");
            step.AddString(Tags.StepDivision, "1");
            step.AddString(Tags.AltNumber, "ALT1");

            var wpAry = new TfMsgAry();
            var wp = new TfMsg();
            wp.AddString(Tags.WpId, "WP001");
            wp.AddString(Tags.WpName, "装置A");
            wpAry.Add(wp);
            step.AddMsgAry(Tags.WpList, wpAry);

            stepAry.Add(step);
            msg.AddMsgAry(Tags.StepList, stepAry);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotCurStateAsync("CAR001");

        Assert.True(result.IsSuccess);
        Assert.Equal("OP01", result.DefaultOpId);
        Assert.Equal("STEP01", result.DefaultStepId);
        Assert.Equal("ALT1", result.DefaultAltNumber);
        Assert.Equal("WP001", result.DefaultWpId);
        Assert.Equal("装置A", result.DefaultWpName);
    }

    [Fact]
    public async Task GetLotCurStateAsync_MultipleSteps_DefaultSetByDivision()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId, "LOT001");

            var stepAry = new TfMsgAry();

            // 1つ目: StepDivision="0" (デフォルトでない)
            var step1 = new TfMsg();
            step1.AddString(Tags.OpId, "OP01");
            step1.AddString(Tags.StepId, "STEP01");
            step1.AddString(Tags.StepDivision, "0");
            step1.AddString(Tags.AltNumber, "");
            step1.AddMsgAry(Tags.WpList, new TfMsgAry());
            stepAry.Add(step1);

            // 2つ目: StepDivision="1" (デフォルト)
            var step2 = new TfMsg();
            step2.AddString(Tags.OpId, "OP02");
            step2.AddString(Tags.StepId, "STEP02");
            step2.AddString(Tags.StepDivision, "1");
            step2.AddString(Tags.AltNumber, "");
            step2.AddMsgAry(Tags.WpList, new TfMsgAry());
            stepAry.Add(step2);

            msg.AddMsgAry(Tags.StepList, stepAry);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotCurStateAsync("CAR001");

        Assert.True(result.IsSuccess);
        Assert.Equal("OP02", result.DefaultOpId);
        Assert.Equal("STEP02", result.DefaultStepId);
    }

    [Fact]
    public async Task GetLotCurStateAsync_NoSteps_DefaultsEmpty()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId, "LOT001");
            msg.AddMsgAry(Tags.StepList, new TfMsgAry());
        });

        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotCurStateAsync("CAR001");

        Assert.True(result.IsSuccess);
        Assert.Equal("", result.DefaultOpId);
        Assert.Equal("", result.DefaultStepId);
    }

    // ──────── GetLotCurStateAsync 異常系 ────────

    [Fact]
    public async Task GetLotCurStateAsync_ErrorResponse_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("ロットが見つかりません");
        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotCurStateAsync("CAR999");

        Assert.False(result.IsSuccess);
        Assert.Contains("ロットが見つかりません", result.ErrorMessage);
    }

    [Fact]
    public async Task GetLotCurStateAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotCurState, new TimeoutException("接続タイムアウト"));
        var svc = CreateService(mock);

        var result = await svc.GetLotCurStateAsync("CAR001");

        Assert.False(result.IsSuccess);
        Assert.Contains("接続タイムアウト", result.ErrorMessage);
    }

    [Fact]
    public async Task GetLotCurStateAsync_SendsClassDivision()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId, "LOT001");
            msg.AddMsgAry(Tags.StepList, new TfMsgAry());
        });

        var mock = TestHelper.CreateMock(MsgIds.LotCurState, response);
        var svc = CreateService(mock);

        await svc.GetLotCurStateAsync("CAR001", classDivision: "14");

        mock.Verify(m => m.SendMessageAsync(
            MsgIds.LotCurState,
            It.Is<string>(s => s.Contains("CLASS_DIVISION") && s.Contains("14")),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetLotCurStateAsync_InvalidResponse_ReturnsFailure()
    {
        var mock = TestHelper.CreateMock(MsgIds.LotCurState, "BROKEN_DATA");
        var svc = CreateService(mock);

        var result = await svc.GetLotCurStateAsync("CAR001");

        Assert.False(result.IsSuccess);
    }
}
