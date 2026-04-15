using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotThrowRsvServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotThrowRsvService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotThrowRsvService>());

    // ──────── ThrowRsvAsync ────────

    [Fact]
    public async Task ThrowRsvAsync_Success_ReturnsLotId()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.LotId, "NEWLOT001"));

        var mock = TestHelper.CreateMock(MsgIds.LotThrowRsv, response);
        var svc = CreateService(mock);

        var result = await svc.ThrowRsvAsync(
            new LotThrowRsvService.LotThrowRsvRequest(
                PdId: "PD01", FlowClass: "TFT", WfNum: "25",
                PlanThrowinDate: "20250420", EngEmpId: "ENG01",
                EmpId: "EMP001", ClassDivision: "1"));

        Assert.Equal("NEWLOT001", result);
    }

    [Fact]
    public async Task ThrowRsvAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse("投入予約失敗");
        var mock = TestHelper.CreateMock(MsgIds.LotThrowRsv, response);
        var svc = CreateService(mock);

        var result = await svc.ThrowRsvAsync(
            new LotThrowRsvService.LotThrowRsvRequest(
                PdId: "PD01", FlowClass: "TFT", WfNum: "25",
                PlanThrowinDate: "20250420", EngEmpId: "ENG01",
                EmpId: "EMP001", ClassDivision: "1"));

        Assert.Null(result);
    }

    [Fact]
    public async Task ThrowRsvAsync_Exception_ReturnsNull()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotThrowRsv, new Exception());
        var svc = CreateService(mock);

        var result = await svc.ThrowRsvAsync(
            new LotThrowRsvService.LotThrowRsvRequest(
                PdId: "PD01", FlowClass: "TFT", WfNum: "25",
                PlanThrowinDate: "20250420", EngEmpId: "ENG01",
                EmpId: "EMP001", ClassDivision: "1"));

        Assert.Null(result);
    }

    [Fact]
    public async Task ThrowRsvAsync_SendsCorrectRequest()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.LotId, "NEWLOT001"));

        var mock = TestHelper.CreateMock(MsgIds.LotThrowRsv, response);
        var svc = CreateService(mock);

        await svc.ThrowRsvAsync(
            new LotThrowRsvService.LotThrowRsvRequest(
                PdId: "PD01", FlowClass: "TFT", WfNum: "25",
                PlanThrowinDate: "20250420", EngEmpId: "ENG01",
                EmpId: "EMP001", ClassDivision: "1"));

        mock.Verify(m => m.SendMessageAsync(
            MsgIds.LotThrowRsv,
            It.Is<string>(s => s.Contains("PD01") && s.Contains("TFT")),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    // ──────── ApproveAsync ────────

    [Fact]
    public async Task ApproveAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotApprove, response);
        var svc = CreateService(mock);

        var result = await svc.ApproveAsync("LOT001", "EMP001");

        Assert.True(result);
    }

    [Fact]
    public async Task ApproveAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotApprove, response);
        var svc = CreateService(mock);

        var result = await svc.ApproveAsync("LOT001", "EMP001");

        Assert.False(result);
    }

    [Fact]
    public async Task ApproveAsync_Exception_ReturnsFalse()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotApprove, new Exception());
        var svc = CreateService(mock);

        var result = await svc.ApproveAsync("LOT001", "EMP001");

        Assert.False(result);
    }
}
