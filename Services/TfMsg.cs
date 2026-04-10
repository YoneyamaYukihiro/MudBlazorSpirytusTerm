using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// TFLib の TfMsg に相当するクラス。
/// VBソース上の lrMsg.addString / laMsg.getString に対応する。
/// メッセージはタグ名=値のキーバリューペアと、配列（TfMsgAry）で構成される。
/// </summary>
public sealed class TfMsg
{
    private readonly Dictionary<string, string>  _strings = new(StringComparer.Ordinal);
    private readonly Dictionary<string, TfMsgAry> _arrays = new(StringComparer.Ordinal);

    // ──────────────────────────────────────────────────────────────
    // VBソース互換メソッド
    // ──────────────────────────────────────────────────────────────

    /// <summary>文字列値を追加する（VB: lrMsg.addString(tag, value)）</summary>
    public void AddString(string name, string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        _strings[name] = value ?? string.Empty;
    }

    /// <summary>文字列値を取得する（VB: laMsg.getString(tag, variable)）</summary>
    public string GetString(string name)
    {
        _strings.TryGetValue(name, out var v);
        return v ?? string.Empty;
    }

    /// <summary>配列を追加する（VB: lrMsg.addMsgAry(tag, ary)）</summary>
    public void AddMsgAry(string name, TfMsgAry ary)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        _arrays[name] = ary ?? new TfMsgAry();
    }

    /// <summary>配列を取得する（VB: laMsg.getMsgAry(tag, ary)）</summary>
    public TfMsgAry GetMsgAry(string name)
    {
        _arrays.TryGetValue(name, out var v);
        return v ?? new TfMsgAry();
    }

    // ──────────────────────────────────────────────────────────────
    // シリアライズ / デシリアライズ（XML形式）
    // TFLibの実際のワイヤフォーマットに合わせて変更する
    // ──────────────────────────────────────────────────────────────

    /// <summary>
    /// このメッセージを XML 文字列に変換する。
    /// ワイヤフォーマットが異なる場合はここを修正すること。
    /// </summary>
    public string ToXml(string rootTag = "MESSAGE")
    {
        var sb = new StringBuilder();
        using var writer = XmlWriter.Create(sb, new XmlWriterSettings
        {
            Indent = false,
            Encoding = Encoding.UTF8,
            OmitXmlDeclaration = true
        });

        writer.WriteStartElement(rootTag);

        foreach (var (k, v) in _strings)
        {
            writer.WriteStartElement(k);
            writer.WriteString(v);
            writer.WriteEndElement();
        }

        foreach (var (k, ary) in _arrays)
        {
            writer.WriteStartElement(k);
            foreach (var item in ary)
            {
                writer.WriteRaw(item.ToXml("ITEM"));
            }
            writer.WriteEndElement();
        }

        writer.WriteEndElement();
        writer.Flush();
        return sb.ToString();
    }

    /// <summary>
    /// XML 文字列からメッセージを復元する。
    /// </summary>
    public static TfMsg FromXml(string xml)
    {
        var msg = new TfMsg();
        if (string.IsNullOrWhiteSpace(xml)) return msg;

        var doc = XDocument.Parse(xml);
        var root = doc.Root ?? throw new InvalidDataException("Invalid TfMsg XML");

        foreach (var elem in root.Elements())
        {
            // 子要素があれば配列、なければ文字列
            if (elem.HasElements)
            {
                var ary = new TfMsgAry();
                foreach (var item in elem.Elements())
                {
                    ary.Add(FromXml(item.ToString()));
                }
                msg._arrays[elem.Name.LocalName] = ary;
            }
            else
            {
                msg._strings[elem.Name.LocalName] = elem.Value;
            }
        }

        return msg;
    }
}
