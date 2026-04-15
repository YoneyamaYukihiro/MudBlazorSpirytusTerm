using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotAttributeServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotAttributeService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotAttributeService>());

    // ──────── GetLotAttributeAsync ────────

    [Fact]
    public async Task GetLotAttributeAsync_Success_ReturnsInfo()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.OrderNum, "ORD001");
            msg.AddString(Tags.LotId, "LOT001");
            msg.AddString(Tags.CarrierId, "CAR001");
            msg.AddString(Tags.PdId, "PD01");
            msg.AddString(Tags.FlowClass, "TFT");
            msg.AddString(Tags.NowSt, "WIP");
            msg.AddString(Tags.WfNum, "25");
            msg.AddString(Tags.LotLastUpdate, "20250415120000");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotAttribute, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotAttributeAsync("LOT001");

        Assert.NotNull(result);
        Assert.Equal("LOT001", result.LotId);
        Assert.Equal("PD01", result.PdId);
    }

    [Fact]
    public async Task GetLotAttributeAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotAttribute, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotAttributeAsync("LOT001");

        Assert.Null(result);
    }

    [Fact]
    public async Task GetLotAttributeAsync_Exception_ReturnsNull()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotAttribute, new Exception());
        var svc = CreateService(mock);

        var result = await svc.GetLotAttributeAsync("LOT001");

        Assert.Null(result);
    }

    // ──────── ChangeAttributeAsync ────────

    [Fact]
    public async Task ChangeAttributeAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotChgAttribute, response);
        var svc = CreateService(mock);

        var result = await svc.ChangeAttributeAsync(
            new LotAttributeService.LotChgAttributeRequest(
                LotId: "LOT001", EmpId: "EMP001",
                LotLastUpdate: "20250415100000"));

        Assert.True(result);
    }

    [Fact]
    public async Task ChangeAttributeAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotChgAttribute, response);
        var svc = CreateService(mock);

        var result = await svc.ChangeAttributeAsync(
            new LotAttributeService.LotChgAttributeRequest(
                LotId: "LOT001", EmpId: "EMP001",
                LotLastUpdate: "20250415100000"));

        Assert.False(result);
    }

    // ──────── CancelPlanAsync ────────

    [Fact]
    public async Task CancelPlanAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotCancelPlan, response);
        var svc = CreateService(mock);

        var result = await svc.CancelPlanAsync("LOT001", "EMP001", "20250415100000");

        Assert.True(result);
    }

    [Fact]
    public async Task CancelPlanAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotCancelPlan, response);
        var svc = CreateService(mock);

        var result = await svc.CancelPlanAsync("LOT001", "EMP001", "20250415100000");

        Assert.False(result);
    }
}
