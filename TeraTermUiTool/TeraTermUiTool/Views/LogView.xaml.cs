using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace TeraTermUiTool.Views;

public partial class LogView : UserControl
{
    public MainWindow? Host { get; set; }

    public LogView()
    {
        InitializeComponent();
    }

    public void Reload()
    {
        if (Host == null) return;
        PathBox.Text = Host.ActiveLog.LogPath;
        AppendBox.IsChecked = Host.ActiveLog.Append;
        BinaryBox.IsChecked = Host.ActiveLog.Binary;
        TimestampBox.IsChecked = Host.ActiveLog.Timestamp;
        HideDialogBox.IsChecked = Host.ActiveLog.HideLogDialog;
        UpdateStatus();
    }

    private void OnAnyChanged(object sender, RoutedEventArgs e) => UpdateStatus();

    private void OnBrowse(object sender, RoutedEventArgs e)
    {
        var dlg = new SaveFileDialog
        {
            Title = "ログファイルの保存先",
            Filter = "ログ (*.log)|*.log|テキスト (*.txt)|*.txt|全て (*.*)|*.*",
            DefaultExt = ".log",
            FileName = "session.log",
        };
        if (dlg.ShowDialog(System.Windows.Window.GetWindow(this)) == true)
        {
            PathBox.Text = dlg.FileName;
        }
    }

    private void OnApply(object sender, RoutedEventArgs e)
    {
        if (Host == null) return;
        Host.ActiveLog.LogPath = PathBox.Text.Trim();
        Host.ActiveLog.Append = AppendBox.IsChecked == true;
        Host.ActiveLog.Binary = BinaryBox.IsChecked == true;
        Host.ActiveLog.Timestamp = TimestampBox.IsChecked == true;
        Host.ActiveLog.HideLogDialog = HideDialogBox.IsChecked == true;
        UpdateStatus();
        Host.SetStatus("ログ設定を適用しました（次回接続から有効）");
    }

    private void OnDisable(object sender, RoutedEventArgs e)
    {
        if (Host == null) return;
        Host.ActiveLog.LogPath = "";
        PathBox.Text = "";
        UpdateStatus();
        Host.SetStatus("ログ設定を解除しました");
    }

    private void UpdateStatus()
    {
        if (Host == null) return;
        var path = PathBox.Text.Trim();
        if (string.IsNullOrEmpty(path))
        {
            StatusBox.Text = "ログは無効です。";
            return;
        }
        var parts = new System.Text.StringBuilder();
        parts.Append("ログ出力先: ").AppendLine(path);
        parts.Append("モード: ");
        parts.Append(AppendBox.IsChecked == true ? "追記 " : "上書き ");
        if (BinaryBox.IsChecked == true) parts.Append("/ バイナリ ");
        if (TimestampBox.IsChecked == true) parts.Append("/ タイムスタンプ ");
        if (HideDialogBox.IsChecked == true) parts.Append("/ ダイアログ非表示 ");
        StatusBox.Text = parts.ToString();
    }
}
