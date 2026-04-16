using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class EquipmentServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private EquipmentService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<EquipmentService>());

    // 笏笏笏笏笏笏笏笏 GetMcGroupListAsync 笏笏笏笏笏笏笏笏

    [Fact]
    public async Task GetMcGroupListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var g = new TfMsg();
            g.AddString(Tags.McGroupId, "GRP01");
            g.AddString(Tags.McGroupName, "TestGroup");
            g.AddString(Tags.BatchFlag, "0");
            ary.Add(g);
            msg.AddMsgAry(Tags.McGroupList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasMcGroupList, response);
        var svc = CreateService(mock);

        var result = await svc.GetMcGroupListAsync();

        Assert.Single(result);
        Assert.Equal("GRP01", result[0].Id);
        Assert.Equal("TestGroup", result[0].Name);
        Assert.Equal("0", result[0].BatchFlag);
    }

    [Fact]
    public async Task GetMcGroupListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasMcGroupList, response);
        var svc = CreateService(mock);

        var result = await svc.GetMcGroupListAsync();

        Assert.Empty(result);
    }

    [Fact]
    public async Task GetMcGroupListAsync_Exception_ReturnsEmpty()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.MasMcGroupList, new Exception());
        var svc = CreateService(mock);

        var result = await svc.GetMcGroupListAsync();

        Assert.Empty(result);
    }

    // 笏笏笏笏笏笏笏笏 GetEquipmentStateAsync 笏笏笏笏笏笏笏笏

    [Fact]
    public async Task GetEquipmentStateAsync_Success_ReturnsState()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.MesModeId, "MODE01");
            msg.AddString(Tags.MesModeType, "AUTO");
            msg.AddString(Tags.ModeStatus, "RUN");
            msg.AddString(Tags.UseId, "USE01");
            msg.AddString(Tags.UseName, "騾壼ｸｸ菴ｿ逕ｨ");
            msg.AddString(Tags.WpTypeFlag, "0");
            msg.AddString(Tags.WpStopFlag, "0");
            msg.AddString(Tags.WpStatusName, "遞ｼ蜍穂ｸｭ");
            msg.AddString(Tags.CollectTypeFlag, "0");
            msg.AddString(Tags.RecipeFlowNum, "1");
            msg.AddString(Tags.WpCancelCarrierFlag, "0");
            msg.AddString(Tags.McType, "CVD");

            var portAry = new TfMsgAry();
            var p = new TfMsg();
            p.AddString(Tags.PortId, "PORT01");
            p.AddString(Tags.PortStatus, "READY");
            portAry.Add(p);
            msg.AddMsgAry(Tags.PortList, portAry);
        });

        var mock = TestHelper.CreateMock(MsgIds.EqState, response);
        var svc = CreateService(mock);

        var result = await svc.GetEquipmentStateAsync("WP001");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal("MODE01", result.Data!.MesModeId);
        Assert.Equal("遞ｼ蜍穂ｸｭ", result.Data!.WpStatusName);
        Assert.Single(result.Data!.PortList);
        Assert.Equal("PORT01", result.Data!.PortList[0].PortId);
    }

    [Fact]
    public async Task GetEquipmentStateAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.EqState, response);
        var svc = CreateService(mock);

        var result = await svc.GetEquipmentStateAsync("WP001");

        Assert.False(result.IsSuccess);
    }

    // 笏笏笏笏笏笏笏笏 GetStockerListAsync 笏笏笏笏笏笏笏笏

    [Fact]
    public async Task GetStockerListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var s = new TfMsg();
            s.AddString(Tags.StockerId, "STK01");
            s.AddString(Tags.StockerName, "繧ｹ繝医ャ繧ｫ繝ｼA");
            ary.Add(s);
            msg.AddMsgAry(Tags.StockerList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasStockerList, response);
        var svc = CreateService(mock);

        var result = await svc.GetStockerListAsync();

        Assert.Single(result);
        Assert.Equal("STK01", result[0].StockerId);
    }
}

