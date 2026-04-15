using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class MenuServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private MenuService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<MenuService>());

    // ──────── GetFlowFavoritesAsync ────────

    [Fact]
    public async Task GetFlowFavoritesAsync_Success_ReturnsFavorites()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.TakingOverFlag, "0");
            var ary = new TfMsgAry();
            var f1 = new TfMsg();
            f1.AddString(Tags.SeqNum, "1");
            f1.AddString(Tags.FunctionId, "EN0030");
            ary.Add(f1);
            var f2 = new TfMsg();
            f2.AddString(Tags.SeqNum, "2");
            f2.AddString(Tags.FunctionId, "EN0060");
            ary.Add(f2);
            msg.AddMsgAry(Tags.FavoriteList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.UtilRefMenu, response);
        var svc = CreateService(mock);

        var result = await svc.GetFlowFavoritesAsync();

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.List);
        Assert.Equal(2, result.List.Count);
        Assert.Equal("EN0030", result.List[0].FunctionId);
        Assert.Equal("EN0060", result.List[1].FunctionId);
    }

    [Fact]
    public async Task GetFlowFavoritesAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("メニュー取得失敗");
        var mock = TestHelper.CreateMock(MsgIds.UtilRefMenu, response);
        var svc = CreateService(mock);

        var result = await svc.GetFlowFavoritesAsync();

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetFlowFavoritesAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.UtilRefMenu, new Exception("通信エラー"));
        var svc = CreateService(mock);

        var result = await svc.GetFlowFavoritesAsync();

        Assert.False(result.IsSuccess);
    }

    // ──────── GetToolFavoritesAsync ────────

    [Fact]
    public async Task GetToolFavoritesAsync_Success_ReturnsFavorites()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var f = new TfMsg();
            f.AddString(Tags.SeqNum, "1");
            f.AddString(Tags.FunctionId, "EN0150");
            ary.Add(f);
            msg.AddMsgAry(Tags.FavoriteList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.UtilRefMenu, response);
        var svc = CreateService(mock);

        var result = await svc.GetToolFavoritesAsync();

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.List);
        Assert.Single(result.List);
    }

    // ──────── GetInformationAsync ────────

    [Fact]
    public async Task GetInformationAsync_Success_ReturnsText()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.Information, "本日のお知らせ：定期メンテナンス予定"));

        var mock = TestHelper.CreateMock(MsgIds.UtilInformation, response);
        var svc = CreateService(mock);

        var result = await svc.GetInformationAsync();

        Assert.True(result.IsSuccess);
        Assert.Contains("定期メンテナンス", result.Text);
    }

    [Fact]
    public async Task GetInformationAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.UtilInformation, response);
        var svc = CreateService(mock);

        var result = await svc.GetInformationAsync();

        Assert.False(result.IsSuccess);
    }
}
