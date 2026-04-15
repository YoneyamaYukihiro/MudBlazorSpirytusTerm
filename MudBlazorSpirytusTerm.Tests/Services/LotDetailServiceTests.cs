using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotDetailServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotDetailService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotDetailService>());

    private static string BuildDetailResponse()
    {
        return TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.LotId, "LOT001");
            msg.AddString(Tags.CarrierId, "CAR001");
            msg.AddString(Tags.PdId, "PD01");
            msg.AddString(Tags.FlowClass, "TFT");
            msg.AddString(Tags.NowSt, "WIP");
            msg.AddString(Tags.WfNum, "25");
            msg.AddString(Tags.OpId, "OP01");
            msg.AddString(Tags.StepId, "STEP01");
            msg.AddString(Tags.LotLastUpdate, "20250415120000");
            msg.AddString(Tags.EngEmpName, "管理者A");
            msg.AddString(Tags.LotHoldFlag, "0");
            msg.AddString(Tags.LotPriority, "5");

            var divAry = new TfMsgAry();
            var div = new TfMsg();
            div.AddString(Tags.DivideLotId, "LOT001A");
            divAry.Add(div);
            msg.AddMsgAry(Tags.DivideLotList, divAry);
        });
    }

    // ──────── GetByCarrierAsync ────────

    [Fact]
    public async Task GetByCarrierAsync_Success_ReturnsDetail()
    {
        var response = BuildDetailResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotDetail, response);
        var svc = CreateService(mock);

        var result = await svc.GetByCarrierAsync("CAR001");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Detail);
        Assert.Equal("LOT001", result.Detail.LotId);
        Assert.Equal("PD01", result.Detail.PdId);
        Assert.Single(result.Detail.DivideLotList);
        Assert.Equal("LOT001A", result.Detail.DivideLotList[0].DivideLotId);
    }

    [Fact]
    public async Task GetByCarrierAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("ロットが見つかりません");
        var mock = TestHelper.CreateMock(MsgIds.LotDetail, response);
        var svc = CreateService(mock);

        var result = await svc.GetByCarrierAsync("CAR999");

        Assert.False(result.IsSuccess);
        Assert.Contains("ロットが見つかりません", result.ErrorMessage);
    }

    [Fact]
    public async Task GetByCarrierAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotDetail, new Exception("エラー"));
        var svc = CreateService(mock);

        var result = await svc.GetByCarrierAsync("CAR001");

        Assert.False(result.IsSuccess);
    }

    // ──────── GetByLotAsync ────────

    [Fact]
    public async Task GetByLotAsync_Success_ReturnsDetail()
    {
        var response = BuildDetailResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotDetail, response);
        var svc = CreateService(mock);

        var result = await svc.GetByLotAsync("LOT001");

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001", result.Detail!.LotId);
    }

    [Fact]
    public async Task GetByLotAsync_SendsLotIdInRequest()
    {
        var response = BuildDetailResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotDetail, response);
        var svc = CreateService(mock);

        await svc.GetByLotAsync("LOT999");

        mock.Verify(m => m.SendMessageAsync(
            MsgIds.LotDetail,
            It.Is<string>(s => s.Contains("LOT999")),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}
