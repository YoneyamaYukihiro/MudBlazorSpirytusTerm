using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class EquipmentModeServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private EquipmentModeService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<EquipmentModeService>());

    // ──────── ChangeOperationModeAsync ────────

    [Fact]
    public async Task ChangeOperationModeAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.Msg, "モード変更完了");
            msg.AddString(Tags.MsgCode, "G001");
            msg.AddString(Tags.EntryTime, "20250415120000");
        });

        var mock = TestHelper.CreateMock(MsgIds.EqChgMode, response);
        var svc = CreateService(mock);

        var result = await svc.ChangeOperationModeAsync(
            new EquipmentModeService.EqChgModeRequest(
                WpId: "WP001", MesModeId: "MODE02", EmpId: "EMP001"));

        Assert.True(result.IsSuccess);
        Assert.Equal("モード変更完了", result.GuidanceMsg);
        Assert.Equal("20250415120000", result.EntryTime);
    }

    [Fact]
    public async Task ChangeOperationModeAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("モード変更失敗");
        var mock = TestHelper.CreateMock(MsgIds.EqChgMode, response);
        var svc = CreateService(mock);

        var result = await svc.ChangeOperationModeAsync(
            new EquipmentModeService.EqChgModeRequest(
                WpId: "WP001", MesModeId: "MODE02", EmpId: "EMP001"));

        Assert.False(result.IsSuccess);
        Assert.Contains("モード変更失敗", result.ErrorMessage);
    }

    [Fact]
    public async Task ChangeOperationModeAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.EqChgMode, new TimeoutException("タイムアウト"));
        var svc = CreateService(mock);

        var result = await svc.ChangeOperationModeAsync(
            new EquipmentModeService.EqChgModeRequest(
                WpId: "WP001", MesModeId: "MODE02", EmpId: "EMP001"));

        Assert.False(result.IsSuccess);
    }

    // ──────── ForceChangeOperationModeAsync ────────

    [Fact]
    public async Task ForceChangeOperationModeAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.Msg, "強制変更完了"));

        var mock = TestHelper.CreateMock(MsgIds.EqEmgChgMode, response);
        var svc = CreateService(mock);

        var result = await svc.ForceChangeOperationModeAsync(
            new EquipmentModeService.EqChgModeRequest(
                WpId: "WP001", MesModeId: "MODE03", EmpId: "EMP001"));

        Assert.True(result.IsSuccess);
    }

    // ──────── ChangeTransportStatusAsync ────────

    [Fact]
    public async Task ChangeTransportStatusAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.EqChgTrnStat, response);
        var svc = CreateService(mock);

        var ports = new[] { new EquipmentModeService.TransportPort("PORT01", "1") };
        var result = await svc.ChangeTransportStatusAsync(
            new EquipmentModeService.ChangeTrnStatRequest(
                WpId: "WP001", EmpId: "EMP001", PortList: ports));

        Assert.True(result);
    }

    [Fact]
    public async Task ChangeTransportStatusAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.EqChgTrnStat, response);
        var svc = CreateService(mock);

        var ports = new[] { new EquipmentModeService.TransportPort("PORT01", "1") };
        var result = await svc.ChangeTransportStatusAsync(
            new EquipmentModeService.ChangeTrnStatRequest(
                WpId: "WP001", EmpId: "EMP001", PortList: ports));

        Assert.False(result);
    }

    // ──────── GetWpUseListAsync ────────

    [Fact]
    public async Task GetWpUseListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var item = new TfMsg();
            item.AddString(Tags.UseId, "USE01");
            item.AddString(Tags.UseName, "通常");
            item.AddString(Tags.UseEnableMode, "1");
            item.AddString(Tags.UseStopFlag, "0");
            item.AddString(Tags.MessageId, "MSG01");
            item.AddString(Tags.MessageText, "テストメッセージ");
            item.AddString(Tags.NormalStateFlag, "1");
            ary.Add(item);
            msg.AddMsgAry(Tags.UseList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasWpUseList, response);
        var svc = CreateService(mock);

        var result = await svc.GetWpUseListAsync();

        Assert.Single(result);
        Assert.Equal("USE01", result[0].UseId);
        Assert.Equal("通常", result[0].UseName);
    }

    // ──────── ChangeWpUseAsync ────────

    [Fact]
    public async Task ChangeWpUseAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.EntryTime, "20250415130000"));

        var mock = TestHelper.CreateMock(MsgIds.EqChgUse, response);
        var svc = CreateService(mock);

        var result = await svc.ChangeWpUseAsync(
            new EquipmentModeService.ChangeWpUseRequest(
                WpId: "WP001", UseId: "USE02", EmpId: "EMP001"));

        Assert.True(result.IsSuccess);
        Assert.Equal("20250415130000", result.EntryTime);
    }

    [Fact]
    public async Task ChangeWpUseAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("変更失敗");
        var mock = TestHelper.CreateMock(MsgIds.EqChgUse, response);
        var svc = CreateService(mock);

        var result = await svc.ChangeWpUseAsync(
            new EquipmentModeService.ChangeWpUseRequest(
                WpId: "WP001", UseId: "USE02", EmpId: "EMP001"));

        Assert.False(result.IsSuccess);
        Assert.Contains("変更失敗", result.ErrorMessage);
    }

    // ──────── CarrierUnloadAsync ────────

    [Fact]
    public async Task CarrierUnloadAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.EqCarUnload, response);
        var svc = CreateService(mock);

        var result = await svc.CarrierUnloadAsync("WP001", "PORT01", "CAR001", "EMP001");

        Assert.True(result);
    }

    [Fact]
    public async Task CarrierUnloadAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.EqCarUnload, response);
        var svc = CreateService(mock);

        var result = await svc.CarrierUnloadAsync("WP001", "PORT01", "CAR001", "EMP001");

        Assert.False(result);
    }
}
