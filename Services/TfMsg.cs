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

    /// <summary>
    /// 文字列値を取得する（VB: laMsg.getString(tag, variable)）。
    /// 受信値中の &amp;rpar; はプロジェクト規約により改行文字に変換する。
    /// </summary>
    public string GetString(string name)
    {
        _strings.TryGetValue(name, out var v);
        return (v ?? string.Empty).Replace("&rpar;", "\n");
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

    // ──────────────────────────────────────────────────────────────
    // TFLib ネイティブ形式シリアライズ / デシリアライズ
    // フォーマット例: (KEY1="value1" KEY2="value2" ARY=((K3="v3")(K3="v4")))
    // ──────────────────────────────────────────────────────────────

    /// <summary>
    /// TFLib ネイティブ形式の文字列に変換する。
    /// </summary>
    public string ToTfString()
    {
        var sb = new StringBuilder("(");
        bool first = true;
        foreach (var (k, v) in _strings)
        {
            if (!first) sb.Append(' ');
            sb.Append(k).Append("=\"").Append(v.Replace("\\", "\\\\").Replace("\"", "\\\"")).Append('"');
            first = false;
        }
        foreach (var (k, ary) in _arrays)
        {
            if (!first) sb.Append(' ');
            sb.Append(k).Append("=(");
            foreach (var item in ary)
                sb.Append(item.ToTfString());
            sb.Append(')');
            first = false;
        }
        sb.Append(')');
        return sb.ToString();
    }

    /// <summary>
    /// TFLib ネイティブ形式の文字列からメッセージを復元する。
    /// </summary>
    public static TfMsg FromTfString(string text)
    {
        int pos = 0;
        return ParseTfMsg(text.AsSpan(), ref pos);
    }

    private static TfMsg ParseTfMsg(ReadOnlySpan<char> s, ref int pos)
    {
        SkipSpaces(s, ref pos);
        if (pos >= s.Length || s[pos] != '(')
            throw new FormatException($"Expected '(' at position {pos}");
        pos++; // consume '('

        var msg = new TfMsg();
        while (pos < s.Length)
        {
            SkipSpaces(s, ref pos);
            if (pos >= s.Length || s[pos] == ')')
            {
                if (pos < s.Length) pos++;
                break;
            }

            int keyStart = pos;
            while (pos < s.Length && s[pos] != '=' && s[pos] != ' ' && s[pos] != ')')
                pos++;
            var key = new string(s[keyStart..pos]);
            if (key.Length == 0) break;

            SkipSpaces(s, ref pos);
            if (pos >= s.Length || s[pos] != '=') break;
            pos++; // consume '='

            SkipSpaces(s, ref pos);
            if (pos >= s.Length) break;

            if (s[pos] == '"')
            {
                pos++; // consume opening '"'
                var valueSb = new StringBuilder();
                while (pos < s.Length && s[pos] != '"')
                {
                    if (s[pos] == '\\' && pos + 1 < s.Length)
                    {
                        pos++;
                        valueSb.Append(s[pos]);
                    }
                    else
                    {
                        valueSb.Append(s[pos]);
                    }
                    pos++;
                }
                if (pos < s.Length) pos++; // consume closing '"'
                msg._strings[key] = valueSb.ToString();
            }
            else if (s[pos] == '(')
            {
                pos++; // consume array container '('
                var ary = new TfMsgAry();
                while (pos < s.Length)
                {
                    SkipSpaces(s, ref pos);
                    if (pos >= s.Length || s[pos] == ')')
                    {
                        if (pos < s.Length) pos++;
                        break;
                    }
                    if (s[pos] == '(')
                        ary.Add(ParseTfMsg(s, ref pos));
                    else
                        break;
                }
                msg._arrays[key] = ary;
            }
        }
        return msg;
    }

    private static void SkipSpaces(ReadOnlySpan<char> s, ref int pos)
    {
        while (pos < s.Length && s[pos] == ' ') pos++;
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
