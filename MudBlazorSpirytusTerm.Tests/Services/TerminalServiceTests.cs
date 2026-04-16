using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class TerminalServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private TerminalService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<TerminalService>());

    // ──────── GetTerminalInfoAsync ────────

    [Fact]
    public async Task GetTerminalInfoAsync_Success_ReturnsInfo()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.WpId, "WP001");
            msg.AddString(Tags.McGroupId, "GRP01");
            msg.AddString(Tags.OpId, "OP01");
            msg.AddString(Tags.StepId, "STEP01");
            msg.AddString(Tags.CarrierTypeId, "CT01");
        });

        var mock = TestHelper.CreateMock(MsgIds.UtilRefTmInfo, response);
        var svc = CreateService(mock);

        var result = await svc.GetTerminalInfoAsync("HOST01");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal("WP001", result.Data!.WpId);
        Assert.Equal("GRP01", result.Data!.McGroupId);
    }

    [Fact]
    public async Task GetTerminalInfoAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.UtilRefTmInfo, response);
        var svc = CreateService(mock);

        var result = await svc.GetTerminalInfoAsync("HOST01");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetTerminalInfoAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.UtilRefTmInfo, new Exception());
        var svc = CreateService(mock);

        var result = await svc.GetTerminalInfoAsync("HOST01");

        Assert.False(result.IsSuccess);
    }

    // ──────── SaveTerminalInfoAsync ────────

    [Fact]
    public async Task SaveTerminalInfoAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.UtilRegTmInfo, response);
        var svc = CreateService(mock);

        var result = await svc.SaveTerminalInfoAsync("1", "HOST01", "WP001", "GRP01");

        Assert.True(result);
    }

    [Fact]
    public async Task SaveTerminalInfoAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.UtilRegTmInfo, response);
        var svc = CreateService(mock);

        var result = await svc.SaveTerminalInfoAsync("1", "HOST01", "WP001", "GRP01");

        Assert.False(result);
    }
}
