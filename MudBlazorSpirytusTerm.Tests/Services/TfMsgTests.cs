using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests.Services;

/// <summary>
/// TfMsg / TfMsgAry のシリアライズ・デシリアライズのテスト。
/// </summary>
public class TfMsgTests
{
    // ──────── ToTfString / FromTfString 往復 ────────

    [Fact]
    public void RoundTrip_SimpleStrings()
    {
        var original = new TfMsg();
        original.AddString("KEY1", "value1");
        original.AddString("KEY2", "value2");

        var text = original.ToTfString();
        var restored = TfMsg.FromTfString(text);

        Assert.Equal("value1", restored.GetString("KEY1"));
        Assert.Equal("value2", restored.GetString("KEY2"));
    }

    [Fact]
    public void RoundTrip_WithArray()
    {
        var original = new TfMsg();
        original.AddString("RET", "0");

        var ary = new TfMsgAry();
        var item1 = new TfMsg();
        item1.AddString("ID", "A001");
        item1.AddString("NAME", "テスト1");
        ary.Add(item1);

        var item2 = new TfMsg();
        item2.AddString("ID", "A002");
        item2.AddString("NAME", "テスト2");
        ary.Add(item2);

        original.AddMsgAry("LIST", ary);

        var text = original.ToTfString();
        var restored = TfMsg.FromTfString(text);

        Assert.Equal("0", restored.GetString("RET"));

        var restoredAry = restored.GetMsgAry("LIST");
        Assert.Equal(2, restoredAry.Count);
        Assert.Equal("A001", restoredAry[0].GetString("ID"));
        Assert.Equal("テスト2", restoredAry[1].GetString("NAME"));
    }

    [Fact]
    public void RoundTrip_EscapedQuotesAndBackslashes()
    {
        var original = new TfMsg();
        original.AddString("MSG", "He said \"hello\" \\ goodbye");

        var text = original.ToTfString();
        var restored = TfMsg.FromTfString(text);

        Assert.Equal("He said \"hello\" \\ goodbye", restored.GetString("MSG"));
    }

    [Fact]
    public void RoundTrip_EmptyString()
    {
        var original = new TfMsg();
        original.AddString("EMPTY", "");

        var text = original.ToTfString();
        var restored = TfMsg.FromTfString(text);

        Assert.Equal("", restored.GetString("EMPTY"));
    }

    // ──────── GetString のデフォルト動作 ────────

    [Fact]
    public void GetString_MissingKey_ReturnsEmpty()
    {
        var msg = new TfMsg();
        Assert.Equal("", msg.GetString("NONEXISTENT"));
    }

    [Fact]
    public void GetString_DecodesParenEntities()
    {
        var msg = new TfMsg();
        msg.AddString("VAL", "abc&lpar;def&rpar;ghi");

        Assert.Equal("abc(def)ghi", msg.GetString("VAL"));
    }

    // ──────── GetMsgAry のデフォルト動作 ────────

    [Fact]
    public void GetMsgAry_MissingKey_ReturnsEmptyAry()
    {
        var msg = new TfMsg();
        var ary = msg.GetMsgAry("NONEXISTENT");

        Assert.NotNull(ary);
        Assert.Empty(ary);
    }

    // ──────── FromTfString エッジケース ────────

    [Fact]
    public void FromTfString_EmptyParens_ReturnsEmptyMsg()
    {
        var msg = TfMsg.FromTfString("()");
        Assert.Equal("", msg.GetString("ANYTHING"));
    }

    [Fact]
    public void FromTfString_InvalidFormat_ThrowsFormatException()
    {
        Assert.Throws<FormatException>(() => TfMsg.FromTfString("NOT_VALID"));
    }

    [Fact]
    public void FromTfString_NestedArrays()
    {
        var text = "(RET=\"0\" ITEMS=((A=\"1\" B=\"2\")(A=\"3\" B=\"4\")))";
        var msg = TfMsg.FromTfString(text);

        Assert.Equal("0", msg.GetString("RET"));
        var items = msg.GetMsgAry("ITEMS");
        Assert.Equal(2, items.Count);
        Assert.Equal("1", items[0].GetString("A"));
        Assert.Equal("4", items[1].GetString("B"));
    }

    // ──────── XML 往復 ────────

    [Fact]
    public void RoundTrip_Xml_SimpleStrings()
    {
        var original = new TfMsg();
        original.AddString("K1", "V1");
        original.AddString("K2", "V2");

        var xml = original.ToXml();
        var restored = TfMsg.FromXml(xml);

        Assert.Equal("V1", restored.GetString("K1"));
        Assert.Equal("V2", restored.GetString("K2"));
    }

    // ──────── TfMsgAry ────────

    [Fact]
    public void TfMsgAry_ConstructFromEnumerable()
    {
        var msg1 = new TfMsg();
        msg1.AddString("ID", "1");
        var msg2 = new TfMsg();
        msg2.AddString("ID", "2");

        var ary = new TfMsgAry(new[] { msg1, msg2 });

        Assert.Equal(2, ary.Count);
        Assert.Equal("1", ary[0].GetString("ID"));
        Assert.Equal("2", ary[1].GetString("ID"));
    }

    // ──────── 実際のプロトコル形式テスト ────────

    [Fact]
    public void FromTfString_TypicalResponse()
    {
        var response = new TfMsg();
        response.AddString(Tags.Ret, Tags.True);
        response.AddString(Tags.LotId, "LOT001");
        response.AddString(Tags.PdId, "PD-X100");
        response.AddString(Tags.LotLastUpdate, "20250101120000");

        var text = response.ToTfString();
        var parsed = TfMsg.FromTfString(text);

        Assert.Equal(Tags.True, parsed.GetString(Tags.Ret));
        Assert.Equal("LOT001", parsed.GetString(Tags.LotId));
        Assert.Equal("PD-X100", parsed.GetString(Tags.PdId));
    }
}
