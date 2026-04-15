using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

/// <summary>
/// CarrierService のユニットテスト。
/// </summary>
public class CarrierServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private CarrierService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<CarrierService>());

    // ──────── GetCarrierListAsync ────────

    [Fact]
    public async Task GetCarrierListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();

            var c1 = new TfMsg();
            c1.AddString(Tags.CarrierId, "CAR001");
            c1.AddString(Tags.EmptyFlag, "0");
            c1.AddString(Tags.StartTime, "20250101080000");
            c1.AddString(Tags.CleanFlag, "1");
            c1.AddString(Tags.CleanTime, "20250101070000");
            c1.AddString(Tags.TotalUseCount, "100");
            c1.AddString(Tags.CleanCount, "5");
            c1.AddString(Tags.AfterCleanUseCount, "10");
            c1.AddString(Tags.CarrierStatId, "ACTIVE");
            ary.Add(c1);

            var c2 = new TfMsg();
            c2.AddString(Tags.CarrierId, "CAR002");
            c2.AddString(Tags.EmptyFlag, "1");
            c2.AddString(Tags.StartTime, "");
            c2.AddString(Tags.CleanFlag, "0");
            c2.AddString(Tags.CleanTime, "");
            c2.AddString(Tags.TotalUseCount, "50");
            c2.AddString(Tags.CleanCount, "2");
            c2.AddString(Tags.AfterCleanUseCount, "3");
            c2.AddString(Tags.CarrierStatId, "EMPTY");
            ary.Add(c2);

            msg.AddMsgAry(Tags.CarrierList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.CarrList, response);
        var svc = CreateService(mock);

        var result = await svc.GetCarrierListAsync(
            new CarrierService.CarrierListRequest(ClassDivision: "1"));

        Assert.Equal(2, result.Count);
        Assert.Equal("CAR001", result[0].CarrierId);
        Assert.Equal("0", result[0].EmptyFlag);
        Assert.Equal("100", result[0].TotalUseCount);
        Assert.Equal("CAR002", result[1].CarrierId);
        Assert.Equal("1", result[1].EmptyFlag);
    }

    [Fact]
    public async Task GetCarrierListAsync_ErrorResponse_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse("キャリアが見つかりません");
        var mock = TestHelper.CreateMock(MsgIds.CarrList, response);
        var svc = CreateService(mock);

        var result = await svc.GetCarrierListAsync(
            new CarrierService.CarrierListRequest(ClassDivision: "1"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GetCarrierListAsync_Exception_ReturnsEmpty()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.CarrList, new TimeoutException("タイムアウト"));
        var svc = CreateService(mock);

        var result = await svc.GetCarrierListAsync(
            new CarrierService.CarrierListRequest(ClassDivision: "1"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GetCarrierListAsync_SendsCorrectRequest()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddMsgAry(Tags.CarrierList, new TfMsgAry()));

        var mock = TestHelper.CreateMock(MsgIds.CarrList, response);
        var svc = CreateService(mock);

        await svc.GetCarrierListAsync(
            new CarrierService.CarrierListRequest(ClassDivision: "2", CarrierId: "CAR999"));

        mock.Verify(m => m.SendMessageAsync(
            MsgIds.CarrList,
            It.Is<string>(s => s.Contains("CLASS_DIVISION") && s.Contains("CAR999")),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    // ──────── CheckCarrierStateAsync ────────

    [Fact]
    public async Task CheckCarrierStateAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.CarrCurState, response);
        var svc = CreateService(mock);

        var result = await svc.CheckCarrierStateAsync(
            new CarrierService.CarrierStateRequest(CarrierId: "CAR001"));

        Assert.True(result);
    }

    [Fact]
    public async Task CheckCarrierStateAsync_ErrorResponse_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.CarrCurState, response);
        var svc = CreateService(mock);

        var result = await svc.CheckCarrierStateAsync(
            new CarrierService.CarrierStateRequest(CarrierId: "CAR001"));

        Assert.False(result);
    }

    [Fact]
    public async Task CheckCarrierStateAsync_Exception_ReturnsFalse()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.CarrCurState, new Exception("通信エラー"));
        var svc = CreateService(mock);

        var result = await svc.CheckCarrierStateAsync(
            new CarrierService.CarrierStateRequest(CarrierId: "CAR001"));

        Assert.False(result);
    }

    // ──────── ManualCarrierOutAsync ────────

    [Fact]
    public async Task ManualCarrierOutAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.CarrManuOutPort, response);
        var svc = CreateService(mock);

        var result = await svc.ManualCarrierOutAsync("CAR001", "STK01", "EMP001");

        Assert.True(result);
    }

    [Fact]
    public async Task ManualCarrierOutAsync_ErrorResponse_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse("出庫失敗");
        var mock = TestHelper.CreateMock(MsgIds.CarrManuOutPort, response);
        var svc = CreateService(mock);

        var result = await svc.ManualCarrierOutAsync("CAR001", "STK01", "EMP001");

        Assert.False(result);
    }

    [Fact]
    public async Task ManualCarrierOutAsync_SendsCorrectParameters()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.CarrManuOutPort, response);
        var svc = CreateService(mock);

        await svc.ManualCarrierOutAsync("CAR001", "STK01", "EMP001");

        mock.Verify(m => m.SendMessageAsync(
            MsgIds.CarrManuOutPort,
            It.Is<string>(s =>
                s.Contains("CAR001") &&
                s.Contains("STK01") &&
                s.Contains("EMP001")),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task ManualCarrierOutAsync_Exception_ReturnsFalse()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.CarrManuOutPort, new InvalidOperationException());
        var svc = CreateService(mock);

        var result = await svc.ManualCarrierOutAsync("CAR001", "STK01", "EMP001");

        Assert.False(result);
    }
}
