using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotActionServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotActionService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotActionService>());

    // ──────── ChangeControlWpAsync ────────

    [Fact]
    public async Task ChangeControlWpAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.Msg, "制御装置変更完了");
            msg.AddString(Tags.MsgCode, "G001");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotChgCtlwp, response);
        var svc = CreateService(mock);

        var result = await svc.ChangeControlWpAsync(
            new LotActionService.ChangeControlWpRequest(
                WpId: "WP001", LotId: "LOT001", OpId: "OP01",
                StepId: "STEP01", KindFlag: "1", AltNumber: "",
                LotLastUpdate: "20250415100000"));

        Assert.True(result.IsSuccess);
        Assert.Equal("制御装置変更完了", result.GuidanceMsg);
    }

    [Fact]
    public async Task ChangeControlWpAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("変更失敗");
        var mock = TestHelper.CreateMock(MsgIds.LotChgCtlwp, response);
        var svc = CreateService(mock);

        var result = await svc.ChangeControlWpAsync(
            new LotActionService.ChangeControlWpRequest(
                WpId: "WP001", LotId: "LOT001", OpId: "OP01",
                StepId: "STEP01", KindFlag: "1", AltNumber: "",
                LotLastUpdate: "20250415100000"));

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task ChangeControlWpAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotChgCtlwp, new Exception());
        var svc = CreateService(mock);

        var result = await svc.ChangeControlWpAsync(
            new LotActionService.ChangeControlWpRequest(
                WpId: "WP001", LotId: "LOT001", OpId: "OP01",
                StepId: "STEP01", KindFlag: "1", AltNumber: "",
                LotLastUpdate: "20250415100000"));

        Assert.False(result.IsSuccess);
    }

    // ──────── DummyCarOutAsync ────────

    [Fact]
    public async Task DummyCarOutAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.DumyCarOut, response);
        var svc = CreateService(mock);

        var result = await svc.DummyCarOutAsync("WP001", "CAR001", "20250415100000");

        Assert.True(result);
    }

    [Fact]
    public async Task DummyCarOutAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.DumyCarOut, response);
        var svc = CreateService(mock);

        var result = await svc.DummyCarOutAsync("WP001", "CAR001", "20250415100000");

        Assert.False(result);
    }
}
