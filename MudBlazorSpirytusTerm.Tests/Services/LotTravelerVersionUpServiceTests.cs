using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotTravelerVersionUpServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotTravelerVersionUpService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotTravelerVersionUpService>());

    // ──────── GetChgTrvListAsync ────────

    [Fact]
    public async Task GetChgTrvListAsync_Success_ReturnsList()
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
            lot.AddString(Tags.PdVersion, "V1");
            lot.AddString(Tags.LotLastUpdate, "20250415100000");
            ary.Add(lot);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotChgTrvList, response);
        var svc = CreateService(mock);

        var result = await svc.GetChgTrvListAsync(
            pdIds: new[] { "PD01" }, flowClasses: new[] { "TFT" });

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("LOT001", result[0].LotId);
    }

    [Fact]
    public async Task GetChgTrvListAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotChgTrvList, response);
        var svc = CreateService(mock);

        var result = await svc.GetChgTrvListAsync(
            pdIds: Array.Empty<string>(), flowClasses: Array.Empty<string>());

        Assert.Null(result);
    }

    [Fact]
    public async Task GetChgTrvListAsync_Exception_ReturnsNull()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotChgTrvList, new Exception());
        var svc = CreateService(mock);

        var result = await svc.GetChgTrvListAsync(
            pdIds: Array.Empty<string>(), flowClasses: Array.Empty<string>());

        Assert.Null(result);
    }

    // ──────── ChgTravelerAsync ────────

    [Fact]
    public async Task ChgTravelerAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var ans = new TfMsg();
            ans.AddString(Tags.LotId, "LOT001");
            ans.AddString(Tags.OpId, "OP02");
            ans.AddString(Tags.StepId, "STEP02");
            ary.Add(ans);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotChgTraveler, response);
        var svc = CreateService(mock);

        var lots = new[] {
            new LotTravelerVersionUpService.ChgTravelerLotItem("LOT001", "バージョンアップ", "20250415100000")
        };
        var result = await svc.ChgTravelerAsync("EMP001", lots);

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("LOT001", result[0].LotId);
    }

    [Fact]
    public async Task ChgTravelerAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotChgTraveler, response);
        var svc = CreateService(mock);

        var lots = Array.Empty<LotTravelerVersionUpService.ChgTravelerLotItem>();
        var result = await svc.ChgTravelerAsync("EMP001", lots);

        Assert.Null(result);
    }

    // ──────── ChgTrvProhibitAsync ────────

    [Fact]
    public async Task ChgTrvProhibitAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotChgTrvProhibit, response);
        var svc = CreateService(mock);

        var result = await svc.ChgTrvProhibitAsync("LOT001", "EMP001", "1", "20250415100000");

        Assert.True(result);
    }

    [Fact]
    public async Task ChgTrvProhibitAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotChgTrvProhibit, response);
        var svc = CreateService(mock);

        var result = await svc.ChgTrvProhibitAsync("LOT001", "EMP001", "1", "20250415100000");

        Assert.False(result);
    }

    // ──────── ChkContEtApcAsync ────────

    [Fact]
    public async Task ChkContEtApcAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.Result, "OK"));

        var mock = TestHelper.CreateMock(MsgIds.LotChkContEtApc, response);
        var svc = CreateService(mock);

        var result = await svc.ChkContEtApcAsync("LOT001");

        Assert.Equal("OK", result);
    }

    [Fact]
    public async Task ChkContEtApcAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotChkContEtApc, response);
        var svc = CreateService(mock);

        var result = await svc.ChkContEtApcAsync("LOT001");

        Assert.Null(result);
    }
}
