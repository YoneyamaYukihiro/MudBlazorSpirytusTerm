using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class AbnormalProcessingServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private AbnormalProcessingService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<AbnormalProcessingService>());

    // ──────── GetListAsync ────────

    [Fact]
    public async Task GetListAsync_Success_ReturnsItems()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            var ary = new TfMsgAry();
            var item = new TfMsg();
            item.AddString("EXCP_NO",        "RPT001");
            item.AddString("DOC_CLASS",      "0");
            item.AddString("EXCP_ITEM_NAME", "異常A");
            item.AddString("FIND_EMP_ID",    "EMP001");
            item.AddString("FIND_EMP_NAME",  "山田太郎");
            item.AddMsgAry(Tags.LotList,     new TfMsgAry());
            item.AddMsgAry("TO_EMP_LIST",    new TfMsgAry());
            ary.Add(item);
            msg.AddMsgAry(Tags.ExcpReportList, ary);
        });

        var mock = TestHelper.CreateMock("excp.reportlist", response);
        var svc  = CreateService(mock);

        var result = await svc.GetListAsync("20250401", "20250430");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Items);
        Assert.Single(result.Items);
        Assert.Equal("RPT001", result.Items[0].ExcpNo);
    }

    [Fact]
    public async Task GetListAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("一覧取得エラー");
        var mock = TestHelper.CreateMock("excp.reportlist", response);
        var svc  = CreateService(mock);

        var result = await svc.GetListAsync("20250401", "20250430");

        Assert.False(result.IsSuccess);
        Assert.Contains("一覧取得エラー", result.ErrorMessage);
    }

    [Fact]
    public async Task GetListAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows("excp.reportlist", new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.GetListAsync("20250401", "20250430");

        Assert.False(result.IsSuccess);
    }

    // ──────── ApplyAsync ────────

    [Fact]
    public async Task ApplyAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock("excp.apply___", response);
        var svc  = CreateService(mock);

        var result = await svc.ApplyAsync("RPT001", "EMP001", "20250415100000");

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task ApplyAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("適用エラー");
        var mock = TestHelper.CreateMock("excp.apply___", response);
        var svc  = CreateService(mock);

        var result = await svc.ApplyAsync("RPT001", "EMP001", "20250415100000");

        Assert.False(result.IsSuccess);
    }

    // ──────── CancelApplyAsync ────────

    [Fact]
    public async Task CancelApplyAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock("excp.cancelapply", response);
        var svc  = CreateService(mock);

        var result = await svc.CancelApplyAsync("RPT001", "EMP001", "20250415100000");

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task CancelApplyAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("承認取消エラー");
        var mock = TestHelper.CreateMock("excp.cancelapply", response);
        var svc  = CreateService(mock);

        var result = await svc.CancelApplyAsync("RPT001", "EMP001", "20250415100000");

        Assert.False(result.IsSuccess);
    }

    // ──────── DeleteAsync ────────

    [Fact]
    public async Task DeleteAsync_Success_ReturnsSuccess()
    {
        var response = TestHelper.BuildSuccessResponse();
        var mock = TestHelper.CreateMock("excp.delete__", response);
        var svc  = CreateService(mock);

        var result = await svc.DeleteAsync("RPT001", "EMP001", "20250415100000");

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task DeleteAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("削除エラー");
        var mock = TestHelper.CreateMock("excp.delete__", response);
        var svc  = CreateService(mock);

        var result = await svc.DeleteAsync("RPT001", "EMP001", "20250415100000");

        Assert.False(result.IsSuccess);
    }
}
