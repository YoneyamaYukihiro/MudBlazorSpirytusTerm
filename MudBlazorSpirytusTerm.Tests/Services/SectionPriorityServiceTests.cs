using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class SectionPriorityServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private SectionPriorityService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<SectionPriorityService>());

    // ──────── GetAllEquipmentsAsync ────────

    [Fact]
    public async Task GetAllEquipmentsAsync_Success_ReturnsList()
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

        var result = await svc.GetAllEquipmentsAsync();

        Assert.Single(result);
        Assert.Equal("1AFP310CTS01", result[0].WpId);
    }

    [Fact]
    public async Task GetAllEquipmentsAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasWpList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetAllEquipmentsAsync();

        Assert.Empty(result);
    }

    // ──────── GetOpListAsync ────────

    [Fact]
    public async Task GetOpListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.OpId, "OP01");
            ary.Add(e);
            msg.AddMsgAry(Tags.OpList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasUseOpList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetOpListAsync();

        Assert.Single(result);
        Assert.Equal("OP01", result[0].OpId);
    }

    [Fact]
    public async Task GetOpListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasUseOpList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetOpListAsync();

        Assert.Empty(result);
    }

    // ──────── GetStepListAsync ────────

    [Fact]
    public async Task GetStepListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.StepId, "ST01");
            ary.Add(e);
            msg.AddMsgAry(Tags.StepList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotStepList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetStepListAsync("OP01");

        Assert.Single(result);
        Assert.Equal("ST01", result[0].StepId);
    }

    [Fact]
    public async Task GetStepListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotStepList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetStepListAsync("OP01");

        Assert.Empty(result);
    }

    // ──────── SearchLotsByLotIdAsync ────────

    [Fact]
    public async Task SearchLotsByLotIdAsync_Success_ReturnsLotIds()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.LotId, "LOT001");
            ary.Add(e);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.ProcList, response);
        var svc  = CreateService(mock);

        var result = await svc.SearchLotsByLotIdAsync("LOT001");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.LotIds);
        Assert.Single(result.LotIds);
        Assert.Equal("LOT001", result.LotIds[0]);
    }

    [Fact]
    public async Task SearchLotsByLotIdAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("ロット検索エラー");
        var mock = TestHelper.CreateMock(MsgIds.ProcList, response);
        var svc  = CreateService(mock);

        var result = await svc.SearchLotsByLotIdAsync("LOT001");

        Assert.False(result.IsSuccess);
    }

    // ──────── SearchLotsByEquipmentAsync ────────

    [Fact]
    public async Task SearchLotsByEquipmentAsync_Success_ReturnsLotIds()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.LotId, "LOT001");
            ary.Add(e);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotList, response);
        var svc  = CreateService(mock);

        var result = await svc.SearchLotsByEquipmentAsync("1AFP310CTS01");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.LotIds);
        Assert.Single(result.LotIds);
    }

    [Fact]
    public async Task SearchLotsByEquipmentAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("装置別検索エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotList, response);
        var svc  = CreateService(mock);

        var result = await svc.SearchLotsByEquipmentAsync("1AFP310CTS01");

        Assert.False(result.IsSuccess);
    }

    // ──────── SearchLotsByProcessAsync ────────

    [Fact]
    public async Task SearchLotsByProcessAsync_Success_ReturnsLotIds()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.LotId, "LOT001");
            ary.Add(e);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotOpList, response);
        var svc  = CreateService(mock);

        var result = await svc.SearchLotsByProcessAsync("OP01", "ST01");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.LotIds);
        Assert.Single(result.LotIds);
    }

    [Fact]
    public async Task SearchLotsByProcessAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("工程別検索エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotOpList, response);
        var svc  = CreateService(mock);

        var result = await svc.SearchLotsByProcessAsync("OP01", "ST01");

        Assert.False(result.IsSuccess);
    }

    // ──────── GetSectionPriorityAsync ────────

    [Fact]
    public async Task GetSectionPriorityAsync_Success_ReturnsItems()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.LotId,           "LOT001");
            e.AddString(Tags.GrbClass,        "1");
            e.AddString(Tags.CarrierId,       "CRR001");
            e.AddString(Tags.StartOpId,       "OP01");
            e.AddString(Tags.StartStepId,     "ST01");
            e.AddString(Tags.EndOpId,         "OP02");
            e.AddString(Tags.EndStepId,       "ST02");
            e.AddString(Tags.SectionPriority, "1");
            e.AddString(Tags.EmpName,         "山田太郎");
            e.AddString(Tags.EntryTime,       "20250415100000");
            e.AddString(Tags.OpId,            "OP01");
            e.AddString(Tags.StepId,          "ST01");
            e.AddString(Tags.LotPriority,     "1");
            e.AddString(Tags.LotHoldFlag,     "0");
            e.AddString(Tags.LotStopFlag,     "0");
            ary.Add(e);
            msg.AddMsgAry(Tags.SecPriorityList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotSecPriority, response);
        var svc  = CreateService(mock);

        var result = await svc.GetSectionPriorityAsync(["LOT001"]);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Items);
        Assert.Single(result.Items);
        Assert.Equal("LOT001", result.Items[0].LotId);
    }

    [Fact]
    public async Task GetSectionPriorityAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("区間優先設定取得エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotSecPriority, response);
        var svc  = CreateService(mock);

        var result = await svc.GetSectionPriorityAsync(["LOT001"]);

        Assert.False(result.IsSuccess);
    }

    // ──────── ChangeSectionPriorityAsync ────────

    [Fact]
    public async Task ChangeSectionPriorityAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotChgSecPriority, response);
        var svc  = CreateService(mock);

        var items = new[]
        {
            new SectionPriorityService.ChangeItem(
                "LOT001", "OP01", "ST01", "OP02", "ST02", "1", "EMP001")
        };
        var result = await svc.ChangeSectionPriorityAsync(items);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task ChangeSectionPriorityAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("区間優先設定変更エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotChgSecPriority, response);
        var svc  = CreateService(mock);

        var result = await svc.ChangeSectionPriorityAsync([]);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task ChangeSectionPriorityAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotChgSecPriority, new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.ChangeSectionPriorityAsync([]);

        Assert.False(result.IsSuccess);
    }
}
