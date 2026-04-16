using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class InventoryServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private InventoryService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<InventoryService>());

    // ──────── AsmDivideAsync ────────

    [Fact]
    public async Task AsmDivideAsync_Success_ReturnsTuple()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.DivideLotId1, "LOT001A");
            msg.AddString(Tags.DivideLotId2, "LOT001B");
        });

        var mock = TestHelper.CreateMock(MsgIds.LotAsmDivide, response);
        var svc = CreateService(mock);

        var wf1 = new[] { new InventoryService.WfMapItem("1", "WF01") };
        var wf2 = new[] { new InventoryService.WfMapItem("2", "WF02") };

        var result = await svc.AsmDivideAsync("LOT001", "EMP001", "20250415100000", wf1, wf2);

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001A", result.Data.LotId1);
        Assert.Equal("LOT001B", result.Data.LotId2);
    }

    [Fact]
    public async Task AsmDivideAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotAsmDivide, response);
        var svc = CreateService(mock);

        var result = await svc.AsmDivideAsync("LOT001", "EMP001", "20250415100000",
            Array.Empty<InventoryService.WfMapItem>(), Array.Empty<InventoryService.WfMapItem>());

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task AsmDivideAsync_Exception_ReturnsNull()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotAsmDivide, new Exception());
        var svc = CreateService(mock);

        var result = await svc.AsmDivideAsync("LOT001", "EMP001", "20250415100000",
            Array.Empty<InventoryService.WfMapItem>(), Array.Empty<InventoryService.WfMapItem>());

        Assert.False(result.IsSuccess);
    }

    // ──────── GetHoldListAsync ────────

    [Fact]
    public async Task GetHoldListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var lot = new TfMsg();
            lot.AddString(Tags.CarrierId, "CAR001");
            lot.AddString(Tags.LotId, "LOT001");
            lot.AddString(Tags.FlowClass, "TFT");
            lot.AddString(Tags.PdId, "PD01");
            lot.AddString(Tags.WfQuantity, "25");
            lot.AddString(Tags.ChipQuantity, "100");
            lot.AddString(Tags.StayTime, "24");
            lot.AddString(Tags.LotHoldFlag, "1");
            lot.AddString(Tags.RecordTime, "20250415");
            lot.AddString(Tags.EmpId, "EMP001");
            lot.AddString(Tags.EmpName, "山田");
            lot.AddString(Tags.ReasonCode, "R01");
            lot.AddString(Tags.ReasonName, "品質不良");
            lot.AddString(Tags.Comments, "テスト");
            lot.AddString(Tags.EntryTime, "20250415100000");
            lot.AddString(Tags.LotPriority, "5");
            lot.AddString(Tags.OpId, "OP01");
            lot.AddString(Tags.StepId, "STEP01");
            lot.AddString(Tags.WpId, "WP01");
            lot.AddString(Tags.HoldStayDate, "5");
            lot.AddString(Tags.HoldEmpId, "EMP001");
            lot.AddString(Tags.HoldEmpName, "山田");
            lot.AddString(Tags.WpName, "装置A");
            lot.AddString(Tags.HoldTermDate, "20250430");
            lot.AddString(Tags.EntryId, "E001");
            lot.AddString(Tags.EngEmpId, "ENG01");
            lot.AddString(Tags.EngEmpName, "管理者A");
            lot.AddString(Tags.NowSt, "HOLD");
            lot.AddString(Tags.LcDirection, "1");
            lot.AddString(Tags.SlotSize, "25");
            lot.AddString(Tags.SendSbId, "SB01");
            lot.AddString(Tags.SbArea, "1A0");
            ary.Add(lot);
            msg.AddMsgAry(Tags.LotList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotHoldList, response);
        var svc = CreateService(mock);

        var result = await svc.GetHoldListAsync("1", new[] { "TFT" });

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Single(result.Data!);
        Assert.Equal("LOT001", result.Data![0].LotId);
        Assert.Equal("品質不良", result.Data![0].ReasonName);
    }

    [Fact]
    public async Task GetHoldListAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotHoldList, response);
        var svc = CreateService(mock);

        var result = await svc.GetHoldListAsync("1", new[] { "TFT" });

        Assert.False(result.IsSuccess);
    }

    // ──────── GetLotExamInfoAsync ────────

    [Fact]
    public async Task GetLotExamInfoAsync_Success_ReturnsInfo()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.BoxNo, "BOX01");
            msg.AddString(Tags.FlowClass, "TFT");
            msg.AddString(Tags.WfQuantity, "25");
            msg.AddString(Tags.ChipQuantity, "100");
            msg.AddString(Tags.PdId, "PD01");
            msg.AddString(Tags.AtlasOrderNo, "ATL001");
            msg.AddString(Tags.SendDate, "20250415");
            msg.AddString(Tags.SendSbName, "SB名");
            msg.AddString(Tags.WfThrowinDate, "20250401");
            msg.AddString(Tags.WfThrowinQuantity, "25");
            msg.AddString(Tags.WfFinishDate, "20250410");
            msg.AddString(Tags.WfFinishQuantity, "24");
            msg.AddString(Tags.WfOutQuantity, "1");
            msg.AddString(Tags.WfIssueQuantity, "0");
            msg.AddString(Tags.ChipThrowinQuantity, "100");
            msg.AddString(Tags.ChipOutQuantity, "4");
            msg.AddString(Tags.GoodChipRatio, "96.0");
            msg.AddString(Tags.InvComments, "在庫コメント");
            msg.AddString(Tags.ExtPartCode, "EXT01");

            var wfAry = new TfMsgAry();
            var wf = new TfMsg();
            wf.AddString(Tags.WfId, "WF01");
            wf.AddString(Tags.ChipQuantity, "4");
            wfAry.Add(wf);
            msg.AddMsgAry(Tags.WfList, wfAry);
        });

        var mock = TestHelper.CreateMock(MsgIds.InvGetLotExamInfo, response);
        var svc = CreateService(mock);

        var result = await svc.GetLotExamInfoAsync("LOT001");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal("LOT001", result.Data!.LotId);
        Assert.Equal("96.0", result.Data!.GoodChipRatio);
        Assert.Single(result.Data!.WfList);
        Assert.Equal("WF01", result.Data!.WfList[0].WfId);
    }

    [Fact]
    public async Task GetLotExamInfoAsync_Exception_ReturnsNull()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.InvGetLotExamInfo, new Exception());
        var svc = CreateService(mock);

        var result = await svc.GetLotExamInfoAsync("LOT001");

        Assert.False(result.IsSuccess);
    }

    // ──────── ChgCommAsync ────────

    [Fact]
    public async Task ChgCommAsync_Success_ReturnsLastUpdate()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.LotLastUpdate, "20250415130000"));

        var mock = TestHelper.CreateMock(MsgIds.InvChgComm, response);
        var svc = CreateService(mock);

        var result = await svc.ChgCommAsync("LOT001", "EMP001", "新コメント", "20250415100000");

        Assert.True(result.IsSuccess);
        Assert.Equal("20250415130000", result.Data);
    }

    [Fact]
    public async Task ChgCommAsync_Error_ReturnsNull()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.InvChgComm, response);
        var svc = CreateService(mock);

        var result = await svc.ChgCommAsync("LOT001", "EMP001", "コメント", "20250415100000");

        Assert.False(result.IsSuccess);
    }

    // ──────── CfForwardAsync ────────

    [Fact]
    public async Task CfForwardAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.InvCfForward, response);
        var svc = CreateService(mock);

        var result = await svc.CfForwardAsync("LOT001", "EMP001", "EVT1", "R01", "理由", "100");

        Assert.True(result);
    }

    [Fact]
    public async Task CfForwardAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.InvCfForward, response);
        var svc = CreateService(mock);

        var result = await svc.CfForwardAsync("LOT001", "EMP001", "EVT1", "R01", "理由", "100");

        Assert.False(result);
    }

    // ──────── CancelSendAsync ────────

    [Fact]
    public async Task CancelSendAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotCancelSend, response);
        var svc = CreateService(mock);

        var result = await svc.CancelSendAsync("LOT001", "EMP001", "20250415100000");

        Assert.True(result);
    }

    // ──────── SendAsync ────────

    [Fact]
    public async Task SendAsync_Success_ReturnsTrue()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotSend, response);
        var svc = CreateService(mock);

        var result = await svc.SendAsync("LOT001", "SB02", "BOX01", "EMP001", "20250415100000");

        Assert.True(result);
    }

    [Fact]
    public async Task SendAsync_Error_ReturnsFalse()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotSend, response);
        var svc = CreateService(mock);

        var result = await svc.SendAsync("LOT001", "SB02", "BOX01", "EMP001", "20250415100000");

        Assert.False(result);
    }
}
