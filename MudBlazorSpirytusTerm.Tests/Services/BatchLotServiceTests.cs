using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class BatchLotServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private BatchLotService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<BatchLotService>());

    // ──────── GetMcGroupListAsync ────────

    [Fact]
    public async Task GetMcGroupListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.McGroupId,   "MG01");
            e.AddString(Tags.McGroupName, "炉グループA");
            ary.Add(e);
            msg.AddMsgAry(Tags.McGroupList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasMcGroupList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetMcGroupListAsync();

        Assert.Single(result);
        Assert.Equal("MG01",      result[0].McGroupId);
        Assert.Equal("炉グループA", result[0].McGroupName);
    }

    [Fact]
    public async Task GetMcGroupListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasMcGroupList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetMcGroupListAsync();

        Assert.Empty(result);
    }

    // ──────── GetWpListAsync ────────

    [Fact]
    public async Task GetWpListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.WpId,   "1AFP310CTS01");
            e.AddString(Tags.WpName, "炉装置A");
            ary.Add(e);
            msg.AddMsgAry(Tags.WpList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasWpList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetWpListAsync("MG01");

        Assert.Single(result);
        Assert.Equal("1AFP310CTS01", result[0].WpId);
    }

    [Fact]
    public async Task GetWpListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasWpList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetWpListAsync("MG01");

        Assert.Empty(result);
    }

    // ──────── GetLotListAsync ────────

    [Fact]
    public async Task GetLotListAsync_Success_ReturnsLots()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.CarrierId, "CRR001");
            e.AddString(Tags.LotId,     "LOT001");
            e.AddString(Tags.PdId,      "PD01");
            ary.Add(e);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotMcGpLotList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetLotListAsync("MG01", "1AFP310CTS01");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Lots);
        Assert.Single(result.Lots);
        Assert.Equal("CRR001", result.Lots[0].CarrierId);
        Assert.Equal("LOT001", result.Lots[0].LotId);
    }

    [Fact]
    public async Task GetLotListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("一覧取得エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotMcGpLotList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetLotListAsync("MG01", "1AFP310CTS01");

        Assert.False(result.IsSuccess);
    }

    // ──────── BatchChangeAsync ────────

    [Fact]
    public async Task BatchChangeAsync_Success_ReturnsBatchId()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.BatchId, "BAT001"));

        var mock = TestHelper.CreateMock(MsgIds.BatChange, response);
        var svc  = CreateService(mock);

        var lots = new[]
        {
            new BatchLotService.BatchLotItem("1", "CRR001", "", "LOT001", "20250415100000", "", "", "", "")
        };
        var result = await svc.BatchChangeAsync("06", "BAT001", "1AFP310CTS01", "20", "", "EMP001", lots);

        Assert.True(result.IsSuccess);
        Assert.Equal("BAT001", result.BatchId);
    }

    [Fact]
    public async Task BatchChangeAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("バッチ変更エラー");
        var mock = TestHelper.CreateMock(MsgIds.BatChange, response);
        var svc  = CreateService(mock);

        var result = await svc.BatchChangeAsync("06", "BAT001", "1AFP310CTS01", "20", "", "EMP001", []);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task BatchChangeAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.BatChange, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.BatchChangeAsync("06", "BAT001", "1AFP310CTS01", "20", "", "EMP001", []);

        Assert.False(result.IsSuccess);
    }
}
