using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotListServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotListService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotListService>());

    [Fact]
    public async Task GetLotListAsync_Success_ReturnsResponse()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.WpTypeFlag, "0");
            msg.AddString(Tags.UseId, "USE01");
            msg.AddString(Tags.UseName, "通常");
            msg.AddString(Tags.MesModeId, "MODE01");
            msg.AddString(Tags.WpStopFlag, "0");
            msg.AddString(Tags.WpStatusName, "稼動中");
            msg.AddString(Tags.McType, "CVD");

            var ary = new TfMsgAry();
            var lot = new TfMsg();
            lot.AddString(Tags.LotId, "LOT001");
            lot.AddString(Tags.FlowClass, "TFT");
            lot.AddString(Tags.OpId, "OP01");
            lot.AddString(Tags.StepId, "STEP01");
            lot.AddString(Tags.NowSt, "WIP");
            lot.AddString(Tags.LotManagerName, "山田太郎");
            lot.AddString(Tags.CarrierId, "CAR001");
            lot.AddString(Tags.WfNum, "25");
            lot.AddString(Tags.PdId, "PD01");
            ary.Add(lot);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotList, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotListAsync(
            new LotListService.LotListRequest { WpId = "WP001" });

        Assert.True(result.IsSuccess);
        Assert.Equal("稼動中", result.WpStatusName);
        Assert.NotNull(result.LotList);
        Assert.Single(result.LotList);
        Assert.Equal("LOT001", result.LotList[0].LotId);
    }

    [Fact]
    public async Task GetLotListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("装置が見つかりません");
        var mock = TestHelper.CreateMock(MsgIds.LotList, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotListAsync(
            new LotListService.LotListRequest { WpId = "WP999" });

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetLotListAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotList, new Exception("通信エラー"));
        var svc = CreateService(mock);

        var result = await svc.GetLotListAsync(
            new LotListService.LotListRequest { WpId = "WP001" });

        Assert.False(result.IsSuccess);
    }
}
