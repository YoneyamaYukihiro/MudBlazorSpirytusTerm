using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotActionReservationServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotActionReservationService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotActionReservationService>());

    // ──────── GetStepUsedWpListAsync ────────

    [Fact]
    public async Task GetStepUsedWpListAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.WfActionFlag, "0");
            var ary = new TfMsgAry();
            var step = new TfMsg();
            step.AddString(Tags.OpId, "OP01");
            step.AddString(Tags.StepId, "STEP01");
            step.AddString(Tags.ActionFlag, "1");
            ary.Add(step);
            msg.AddMsgAry(Tags.StepList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasStepUsedWpList, response);
        var svc = CreateService(mock);

        var result = await svc.GetStepUsedWpListAsync("WP001");

        Assert.NotNull(result);
        Assert.Equal("0", result.WfActionFlag);
        Assert.Single(result.Steps);
        Assert.Equal("OP01", result.Steps[0].OpId);
    }

    [Fact]
    public async Task GetStepUsedWpListAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasStepUsedWpList, response);
        var svc = CreateService(mock);

        var result = await svc.GetStepUsedWpListAsync("WP001");

        Assert.Null(result);
    }

    // ──────── GetLotTravelerAsync ────────

    [Fact]
    public async Task GetLotTravelerAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.EngEmpId, "ENG01");
            msg.AddString(Tags.EngEmpName, "管理者A");
            msg.AddString(Tags.FlowClass, "TFT");
            var ary = new TfMsgAry();
            var step = new TfMsg();
            step.AddString(Tags.StepNum, "1");
            step.AddString(Tags.OpId, "OP01");
            step.AddString(Tags.StepId, "STEP01");
            step.AddString(Tags.AltStepFlag, "0");
            step.AddString(Tags.ActionFlag, "0");
            ary.Add(step);
            msg.AddMsgAry(Tags.StepList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotTraveler, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotTravelerAsync("LOT001");

        Assert.NotNull(result);
        Assert.Equal("管理者A", result.EngEmpName);
        Assert.Single(result.Steps);
    }

    [Fact]
    public async Task GetLotTravelerAsync_Exception_ReturnsNull()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotTraveler, new Exception());
        var svc = CreateService(mock);

        var result = await svc.GetLotTravelerAsync("LOT001");

        Assert.Null(result);
    }

    // ──────── SetActionReservationAsync ────────

    [Fact]
    public async Task SetActionReservationAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotActRsv, response);
        var svc = CreateService(mock);

        var result = await svc.SetActionReservationAsync(
            new LotActionReservationService.ActRsvRequest(
                LotActionTypeId: "ACT01", OpId: "OP01", StepId: "STEP01",
                ItemName: "テスト", ActionTrigger: "1", Message: "メッセージ",
                WorkDirectionId: "WD01", EngEmpId: "ENG01", StopHoldFlag: "0",
                HoldReasonId: "", EmpId: "EMP001", StartTime: "", EndTime: "",
                EditTime: "", HoldComments: "", HoldPeriod: "", HoldEmpId: "",
                WfList: Array.Empty<LotActionReservationService.WfListItem>()));

        Assert.True(result);
    }

    [Fact]
    public async Task SetActionReservationAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotActRsv, response);
        var svc = CreateService(mock);

        var result = await svc.SetActionReservationAsync(
            new LotActionReservationService.ActRsvRequest(
                LotActionTypeId: "ACT01", OpId: "OP01", StepId: "STEP01",
                ItemName: "テスト", ActionTrigger: "1", Message: "",
                WorkDirectionId: "", EngEmpId: "", StopHoldFlag: "0",
                HoldReasonId: "", EmpId: "", StartTime: "", EndTime: "",
                EditTime: "", HoldComments: "", HoldPeriod: "", HoldEmpId: "",
                WfList: Array.Empty<LotActionReservationService.WfListItem>()));

        Assert.False(result);
    }

    // ──────── DeleteActionReservationAsync ────────

    [Fact]
    public async Task DeleteActionReservationAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotDelAct, response);
        var svc = CreateService(mock);

        var result = await svc.DeleteActionReservationAsync("ACTID001", "20250415100000");

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteActionReservationAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotDelAct, response);
        var svc = CreateService(mock);

        var result = await svc.DeleteActionReservationAsync("ACTID001", "20250415100000");

        Assert.False(result);
    }
}
