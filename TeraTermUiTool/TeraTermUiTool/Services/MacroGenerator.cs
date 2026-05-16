using System.Collections.Generic;
using System.Text;
using TeraTermUiTool.Models;

namespace TeraTermUiTool.Services;

public static class MacroGenerator
{
    public static string Generate(IEnumerable<MacroStep> steps, string? header = null)
    {
        var sb = new StringBuilder();
        sb.AppendLine("; TeraTermUiTool で生成されたマクロ");
        if (!string.IsNullOrWhiteSpace(header))
        {
            foreach (var line in header.Split('\n'))
                sb.Append("; ").AppendLine(line.TrimEnd('\r'));
        }
        sb.AppendLine();

        foreach (var step in steps)
        {
            sb.AppendLine(RenderStep(step));
        }
        return sb.ToString();
    }

    public static string RenderStep(MacroStep step) => step.Action switch
    {
        MacroAction.Connect => $"connect {TtlString(step.Argument1)}",
        MacroAction.SendLine => $"sendln {TtlString(step.Argument1)}",
        MacroAction.Send => $"send {TtlString(step.Argument1)}",
        MacroAction.Wait => $"wait {TtlString(step.Argument1)}",
        MacroAction.WaitRegex => $"waitregex {TtlString(step.Argument1)}",
        MacroAction.Pause => $"pause {SafeNumber(step.Argument1, 1)}",
        MacroAction.MPause => $"mpause {SafeNumber(step.Argument1, 100)}",
        MacroAction.LogOpen => RenderLogOpen(step),
        MacroAction.LogClose => "logclose",
        MacroAction.Disconnect => "disconnect 0",
        MacroAction.SetSync => $"setsync {SafeNumber(step.Argument1, 0)}",
        MacroAction.Comment => $"; {step.Argument1}",
        _ => "; (未実装)",
    };

    private static string RenderLogOpen(MacroStep step)
    {
        var opts = (step.Argument2 ?? "").ToLowerInvariant();
        var binary = opts.Contains("binary") ? 1 : 0;
        var append = opts.Contains("append") ? 1 : 0;
        return $"logopen {TtlString(step.Argument1)} {binary} {append}";
    }

    private static string TtlString(string s)
    {
        if (s is null) return "''";
        var sb = new StringBuilder();
        sb.Append('\'');
        foreach (var ch in s)
        {
            if (ch == '\'') sb.Append("' #39 '");
            else if (ch == '\r') continue;
            else if (ch == '\n') sb.Append("' #13#10 '");
            else sb.Append(ch);
        }
        sb.Append('\'');
        return sb.ToString();
    }

    private static int SafeNumber(string s, int fallback) =>
        int.TryParse(s, out var n) && n >= 0 ? n : fallback;
}
