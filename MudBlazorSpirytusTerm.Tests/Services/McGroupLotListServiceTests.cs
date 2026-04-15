using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class McGroupLotListServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private McGroupLotListService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<McGroupLotListService>());

    [Fact]
    public async Task GetLotListAsync_Success_ReturnsItems()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var lot = new TfMsg();
            lot.AddString(Tags.LotId, "LOT001");
            lot.AddString(Tags.CarrierId, "CAR001");
            lot.AddString(Tags.OpId, "OP01");
            lot.AddString(Tags.StepId, "STEP01");
            lot.AddString(Tags.NowSt, "WIP");
            lot.AddString(Tags.CurrentPositionName, "装置A");
            lot.AddString(Tags.LotHoldFlag, "0");
            lot.AddString(Tags.LotStopFlag, "0");
            lot.AddString(Tags.ReworkFlag, "0");
            lot.AddString(Tags.WfNum, "25");
            lot.AddString(Tags.LotPriority, "5");
            lot.AddString(Tags.LimitTime, "");
            lot.AddString(Tags.WarnTime, "");
            lot.AddString(Tags.DispatchStartTime, "");
            lot.AddString(Tags.PdId, "PD01");
            lot.AddString(Tags.FlowClass, "TFT");
            lot.AddString(Tags.SendSbId, "");
            lot.AddString(Tags.CfFlag, "0");
            ary.Add(lot);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotMcAllLotList, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotListAsync(mcGroupId: "GRP01");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Items);
        Assert.Single(result.Items);
        Assert.Equal("LOT001", result.Items[0].LotId);
    }

    [Fact]
    public async Task GetLotListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("取得失敗");
        var mock = TestHelper.CreateMock(MsgIds.LotMcAllLotList, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotListAsync();

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetLotListAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotMcAllLotList, new Exception());
        var svc = CreateService(mock);

        var result = await svc.GetLotListAsync();

        Assert.False(result.IsSuccess);
    }
}
