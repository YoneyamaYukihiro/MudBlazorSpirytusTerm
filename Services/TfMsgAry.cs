namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// TFLib の TfMsgAry に相当するクラス。
/// VBソース上の laMsg.getMsgAry で取得する配列に対応する。
/// </summary>
public sealed class TfMsgAry : List<TfMsg>
{
    public TfMsgAry() { }
    public TfMsgAry(IEnumerable<TfMsg> items) : base(items) { }
}
