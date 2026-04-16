using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

public class EquipmentDataServiceTests
{
    private readonly IConfiguration _cfg = TestHelper.CreateConfig();

    private EquipmentDataService CreateService(Mock<ITfMessageClient> mockMq)
        => new(mockMq.Object, _cfg, TestHelper.CreateLogger<EquipmentDataService>());

    // ──────── GetCollectParamsAsync ────────

    [Fact]
    public async Task GetCollectParamsAsync_Success_ReturnsResult()
    {
        var response = TestHelper.BuildSuccessResponse(msg =>
        {
            msg.AddString(Tags.CategoryId, "CAT01");
            var ary = new TfMsgAry();
            var item = new TfMsg();
            item.AddString(Tags.ItemName,   "圧力");
            item.AddString(Tags.CategoryId, "CAT01");
            ary.Add(item);
            msg.AddMsgAry(Tags.CollectionList, ary);
        });

        var mock = TestHelper.CreateMock("lot_.collectparams", response);
        var svc  = CreateService(mock);

        var result = await svc.GetCollectParamsAsync("LOT001", "OP01", "ST01");

        Assert.True(result.IsSuccess);
        Assert.Equal("CAT01", result.CategoryId);
        Assert.NotNull(result.Items);
        Assert.Single(result.Items);
        Assert.Equal("圧力", result.Items[0].ItemName);
    }

    [Fact]
    public async Task GetCollectParamsAsync_Error_ReturnsFailure()
    {
        var response = TestHelper.BuildErrorResponse("データ取得エラー");
        var mock = TestHelper.CreateMock("lot_.collectparams", response);
        var svc  = CreateService(mock);

        var result = await svc.GetCollectParamsAsync("LOT001", "OP01", "ST01");

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetCollectParamsAsync_Exception_ReturnsFailure()
    {
        var mock = TestHelper.CreateMockThrows("lot_.collectparams", new TimeoutException());
        var svc  = CreateService(mock);

        var result = await svc.GetCollectParamsAsync("LOT001", "OP01", "ST01");

        Assert.False(result.IsSuccess);
    }
}
