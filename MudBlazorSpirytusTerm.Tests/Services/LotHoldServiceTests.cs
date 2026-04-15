using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class LotHoldServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private LotHoldService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<LotHoldService>());

    // ──────── GetHoldReasonsAsync ────────

    [Fact]
    public async Task GetHoldReasonsAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var r1 = new TfMsg();
            r1.AddString(Tags.ReasonCode, "R01");
            r1.AddString(Tags.ReasonName, "品質不良");
            ary.Add(r1);
            var r2 = new TfMsg();
            r2.AddString(Tags.ReasonCode, "R02");
            r2.AddString(Tags.ReasonName, "装置異常");
            ary.Add(r2);
            msg.AddMsgAry(Tags.LotReasonCodeList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.MasReasonCode, response);
        var svc = CreateService(mock);

        var result = await svc.GetHoldReasonsAsync();

        Assert.Equal(2, result.Count);
        Assert.Equal("R01", result[0].ReasonCode);
        Assert.Equal("品質不良", result[0].ReasonName);
        Assert.Equal("装置異常", result[1].ReasonName);
    }

    [Fact]
    public async Task GetHoldReasonsAsync_Error_ReturnsEmpty()
    {
        var response = TestHelper.BuildErrorResponse();
        var mock = TestHelper.CreateMock(MsgIds.MasReasonCode, response);
        var svc = CreateService(mock);

        var result = await svc.GetHoldReasonsAsync();

        Assert.Empty(result);
    }

    [Fact]
    public async Task GetHoldReasonsAsync_Exception_ReturnsEmpty()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.MasReasonCode, new TimeoutException());
        var svc = CreateService(mock);

        var result = await svc.GetHoldReasonsAsync();

        Assert.Empty(result);
    }

    // ──────── GetHoldInfoAsync ────────

    [Fact]
    public async Task GetHoldInfoAsync_Success_ReturnsList()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var h = new TfMsg();
            h.AddString(Tags.HoldReasonId, "R01");
            h.AddString(Tags.HoldReasonName, "品質不良");
            h.AddString(Tags.HoldTime, "20250415100000");
            h.AddString(Tags.HoldComments, "テスト保留");
            h.AddString(Tags.HoldEmpId, "EMP001");
            h.AddString(Tags.HoldEmpName, "山田太郎");
            h.AddString(Tags.HoldTermDate, "20250430");
            h.AddString(Tags.HoldStayDate, "15");
            h.AddString(Tags.EntryTime, "20250415100000");
            ary.Add(h);
            msg.AddMsgAry(Tags.HoldList, ary);
        });

        var mock = TestHelper.CreateMock(MsgIds.LotHoldInfo, response);
        var svc = CreateService(mock);

        var result = await svc.GetHoldInfoAsync("LOT001");

        Assert.Single(result);
        Assert.Equal("R01", result[0].HoldReasonId);
        Assert.Equal("山田太郎", result[0].HoldEmpName);
    }

    // ──────── SetHoldAsync ────────

    [Fact]
    public async Task SetHoldAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
            msg.AddString(Tags.HoldTime, "20250415120000"));

        var mock = TestHelper.CreateMock(MsgIds.LotHold, response);
        var svc = CreateService(mock);

        var result = await svc.SetHoldAsync(new LotHoldService.HoldRequest(
            LotId: "LOT001", HoldReasonId: "R01", HoldComments: "テスト",
            HoldTermDate: "20250430", HoldEmpId: "", EmpId: "", LotLastUpdate: "20250415100000"));

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task SetHoldAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("保留に失敗");
        var mock = TestHelper.CreateMock(MsgIds.LotHold, response);
        var svc = CreateService(mock);

        var result = await svc.SetHoldAsync(new LotHoldService.HoldRequest(
            LotId: "LOT001", HoldReasonId: "R01", HoldComments: "",
            HoldTermDate: "", HoldEmpId: "", EmpId: "", LotLastUpdate: "20250415100000"));

        Assert.False(result.IsSuccess);
    }

    // ──────── ReleaseHoldAsync ────────

    [Fact]
    public async Task ReleaseHoldAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock(MsgIds.LotReleaseHold, response);
        var svc = CreateService(mock);

        var result = await svc.ReleaseHoldAsync(new LotHoldService.ReleaseRequest(
            LotId: "LOT001", HoldComments: "解除", EmpId: "EMP001",
            LotLastUpdate: "20250415100000", EntryTime: "20250415090000"));

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task ReleaseHoldAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows(MsgIds.LotReleaseHold, new Exception("通信エラー"));
        var svc = CreateService(mock);

        var result = await svc.ReleaseHoldAsync(new LotHoldService.ReleaseRequest(
            LotId: "LOT001", HoldComments: "", EmpId: "",
            LotLastUpdate: "20250415100000", EntryTime: "20250415090000"));

        Assert.False(result.IsSuccess);
    }
}
