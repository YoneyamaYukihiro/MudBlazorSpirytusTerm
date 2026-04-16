using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class CfLotCompositionServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private CfLotCompositionService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<CfLotCompositionService>());

    // ──────── GetScreenSizeListAsync ────────

    [Fact]
    public async Task GetScreenSizeListAsync_Success_ReturnsItems()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.ScreenSizeId,  "SS01");
            e.AddString(Tags.ChipCount,     "100");
            ary.Add(e);
            msg.AddMsgAry(Tags.ScreenSizeList, ary);
        });

        var mock = TestHelper.CreateMock("mas_.screenlist", response);
        var svc  = CreateService(mock);

        var result = await svc.GetScreenSizeListAsync();

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Items);
        Assert.Single(result.Items);
        Assert.Equal("SS01", result.Items[0].ScreenSizeId);
        Assert.Equal("100",  result.Items[0].ChipCount);
    }

    [Fact]
    public async Task GetScreenSizeListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("マスタ取得エラー");
        var mock = TestHelper.CreateMock("mas_.screenlist", response);
        var svc  = CreateService(mock);

        var result = await svc.GetScreenSizeListAsync();

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetScreenSizeListAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows("mas_.screenlist", new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.GetScreenSizeListAsync();

        Assert.False(result.IsSuccess);
    }

    // ──────── RegisterCfLotAsync ────────

    [Fact]
    public async Task RegisterCfLotAsync_Success_ReturnsLotId()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.LotId, "CFLOT001"));

        var mock = TestHelper.CreateMock("lot_.cfthrowin", response);
        var svc  = CreateService(mock);

        var paletteItems = new[]
        {
            new CfLotCompositionService.PaletteMapItem("1", "PAL001", "10", "LOT001")
        };
        var result = await svc.RegisterCfLotAsync(
            carrierId:  "CRR001",
            empId:      "EMP001",
            num:        "1",
            pdId:       "PDCF01",
            entryId:    "ENT01",
            engEmpId:   "ENG01",
            wpId:       "WP01",
            paletteMap: paletteItems);

        Assert.True(result.IsSuccess);
        Assert.Equal("CFLOT001", result.ReturnLotId);
    }

    [Fact]
    public async Task RegisterCfLotAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("CF編成エラー");
        var mock = TestHelper.CreateMock("lot_.cfthrowin", response);
        var svc  = CreateService(mock);

        var result = await svc.RegisterCfLotAsync("CRR001", "EMP001", "1", "PDCF01", "ENT01", "ENG01", "WP01", []);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task RegisterCfLotAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows("lot_.cfthrowin", new Exception("通信エラー"));
        var svc  = CreateService(mock);

        var result = await svc.RegisterCfLotAsync("CRR001", "EMP001", "1", "PDCF01", "ENT01", "ENG01", "WP01", []);

        Assert.False(result.IsSuccess);
    }
}
