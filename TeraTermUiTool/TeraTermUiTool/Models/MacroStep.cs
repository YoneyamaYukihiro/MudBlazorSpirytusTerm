using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TeraTermUiTool.Models;

public enum MacroAction
{
    Connect,
    SendLine,
    Send,
    Wait,
    WaitRegex,
    Pause,
    MPause,
    LogOpen,
    LogClose,
    Disconnect,
    SetSync,
    Comment,
}

public class MacroStep : INotifyPropertyChanged
{
    private MacroAction _action;
    private string _argument1 = "";
    private string _argument2 = "";

    public MacroAction Action
    {
        get => _action;
        set { _action = value; OnChanged(); OnChanged(nameof(Description)); OnChanged(nameof(Arg1Label)); OnChanged(nameof(Arg2Label)); OnChanged(nameof(Arg2Visible)); }
    }

    public string Argument1
    {
        get => _argument1;
        set { _argument1 = value; OnChanged(); OnChanged(nameof(Description)); }
    }

    public string Argument2
    {
        get => _argument2;
        set { _argument2 = value; OnChanged(); OnChanged(nameof(Description)); }
    }

    public string Description => Action switch
    {
        MacroAction.Connect => $"接続: {Argument1}",
        MacroAction.SendLine => $"送信(改行付き): {Argument1}",
        MacroAction.Send => $"送信: {Argument1}",
        MacroAction.Wait => $"文字列待ち: \"{Argument1}\"",
        MacroAction.WaitRegex => $"正規表現待ち: /{Argument1}/",
        MacroAction.Pause => $"{Argument1} 秒待機",
        MacroAction.MPause => $"{Argument1} ミリ秒待機",
        MacroAction.LogOpen => $"ログ開始: {Argument1}",
        MacroAction.LogClose => "ログ停止",
        MacroAction.Disconnect => "切断",
        MacroAction.SetSync => $"同期モード: {Argument1}",
        MacroAction.Comment => $"; {Argument1}",
        _ => Action.ToString(),
    };

    public string Arg1Label => Action switch
    {
        MacroAction.Connect => "接続文字列",
        MacroAction.SendLine or MacroAction.Send => "送信内容",
        MacroAction.Wait => "待ち受け文字列",
        MacroAction.WaitRegex => "正規表現",
        MacroAction.Pause => "秒数",
        MacroAction.MPause => "ミリ秒",
        MacroAction.LogOpen => "ログファイル",
        MacroAction.SetSync => "0=非同期 / 1=同期",
        MacroAction.Comment => "コメント",
        _ => "引数",
    };

    public string Arg2Label => Action switch
    {
        MacroAction.LogOpen => "オプション(append/binary)",
        _ => "",
    };

    public bool Arg2Visible => Action == MacroAction.LogOpen;

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
