using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotThrowRsvExtServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotThrowRsvExtService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotThrowRsvExtService>());

    // ──────── GetProductListAsync ────────

    [Fact]
    public async Task GetProductListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.PdId,       "PD01");
            e.AddString(Tags.PdName,     "テスト品種");
            e.AddString(Tags.FlowClass,  "1");
            e.AddString(Tags.MaxWfCount, "25");
            ary.Add(e);
            msg.AddMsgAry(Tags.PdList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasPdList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetProductListAsync();

        Assert.Single(result);
        Assert.Equal("PD01",    result[0].PdId);
        Assert.Equal("テスト品種", result[0].PdName);
        Assert.Equal(25,        result[0].MaxWfCount);
    }

    [Fact]
    public async Task GetProductListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasPdList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetProductListAsync();

        Assert.Empty(result);
    }

    // ──────── GetFlowClassListAsync ────────

    [Fact]
    public async Task GetFlowClassListAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var e = new TfMsg();
            e.AddString(Tags.FlowClassId,   "1");
            e.AddString(Tags.FlowClassName, "通常");
            ary.Add(e);
            msg.AddMsgAry(Tags.FlowClassList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasFlowList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetFlowClassListAsync();

        Assert.Single(result);
        Assert.Equal("1",  result[0].FlowClassId);
        Assert.Equal("通常", result[0].FlowClassName);
    }

    [Fact]
    public async Task GetFlowClassListAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasFlowList, response);
        var svc  = CreateService(mock);

        var result = await svc.GetFlowClassListAsync();

        Assert.Empty(result);
    }

    // ──────── RegisterAsync ────────

    [Fact]
    public async Task RegisterAsync_Success_ReturnsLotId()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.LotId, "LOT001"));

        var mock = TestHelper.CreateMock(MsgIds.LotThrowRsv, response);
        var svc  = CreateService(mock);

        var req = new LotThrowRsvExtService.RegisterRequest(
            PdId:            "PD01",
            FlowClass:       "1",
            WfNum:           "25",
            PlanThrowinDate: "20250415",
            EngEmpId:        "EMP001",
            EmpId:           "EMP001",
            ClassDivision:   "0M");
        var result = await svc.RegisterAsync(req);

        Assert.True(result.IsSuccess);
        Assert.Equal("LOT001", result.LotId);
    }

    [Fact]
    public async Task RegisterAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("投入予定登録エラー");
        var mock = TestHelper.CreateMock(MsgIds.LotThrowRsv, response);
        var svc  = CreateService(mock);

        var req = new LotThrowRsvExtService.RegisterRequest(
            "PD01", "1", "25", "20250415", "EMP001", "EMP001", "0M");
        var result = await svc.RegisterAsync(req);

        Assert.False(result.IsSuccess);
        Assert.Contains("投入予定登録エラー", result.ErrorMessage);
    }

    [Fact]
    public async Task RegisterAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotThrowRsv, new TimeoutException());
        var svc  = CreateService(mock);

        var req = new LotThrowRsvExtService.RegisterRequest(
            "PD01", "1", "25", "20250415", "EMP001", "EMP001", "0M");
        var result = await svc.RegisterAsync(req);

        Assert.False(result.IsSuccess);
    }
}
