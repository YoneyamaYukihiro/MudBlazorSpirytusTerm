using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using TeraTermUiTool.Services;

namespace TeraTermUiTool.Views;

public partial class FileTransferView : UserControl
{
    public MainWindow? Host { get; set; }

    public FileTransferView()
    {
        InitializeComponent();
        Loaded += (_, _) => RefreshPreview();
    }

    private string SelectedProto() =>
        ((ProtoBox.SelectedItem as ComboBoxItem)?.Tag as string) ?? "SCP";

    private string SelectedDirection() =>
        ((DirBox.SelectedItem as ComboBoxItem)?.Tag as string) ?? "Upload";

    private void OnAnyChanged(object sender, RoutedEventArgs e) => RefreshPreview();
    private void OnAnyChanged(object sender, TextChangedEventArgs e) => RefreshPreview();
    private void OnAnyChanged(object sender, SelectionChangedEventArgs e) => RefreshPreview();
    private void OnRefresh(object sender, RoutedEventArgs e) => RefreshPreview();

    private void OnBrowseLocal(object sender, RoutedEventArgs e)
    {
        var direction = SelectedDirection();
        if (direction == "Upload")
        {
            var dlg = new OpenFileDialog { Title = "送信するローカルファイルを選択" };
            if (dlg.ShowDialog(System.Windows.Window.GetWindow(this)) == true)
                LocalBox.Text = dlg.FileName;
        }
        else
        {
            var dlg = new SaveFileDialog { Title = "保存先（ダウンロード）" };
            if (dlg.ShowDialog(System.Windows.Window.GetWindow(this)) == true)
                LocalBox.Text = dlg.FileName;
        }
    }

    private void RefreshPreview() => PreviewBox.Text = BuildMacro();

    private string BuildMacro()
    {
        var proto = SelectedProto();
        var direction = SelectedDirection();
        var local = LocalBox.Text.Trim();
        var remote = RemoteBox.Text.Trim();
        var sb = new StringBuilder();
        sb.AppendLine("; TeraTermUiTool ファイル転送マクロ");
        sb.AppendLine("; ※ 既に Tera Term セッションが開いている必要があります。");
        sb.AppendLine();

        switch (proto)
        {
            case "SCP":
                if (direction == "Upload")
                    sb.AppendLine($"scpsend {Quote(local)} {Quote(remote)}");
                else
                    sb.AppendLine($"scprecv {Quote(remote)} {Quote(local)}");
                break;
            case "ZMODEM_SEND":
                sb.AppendLine($"zmodemsend {Quote(local)} 0");
                break;
            case "ZMODEM_RECV":
                sb.AppendLine("; リモート側で sz <file> を実行してから本マクロを起動してください。");
                sb.AppendLine($"changedir {Quote(Path.GetDirectoryName(local) ?? "")}");
                sb.AppendLine("zmodemrecv 0");
                break;
        }
        return sb.ToString();
    }

    private string? AskSavePath()
    {
        var dlg = new SaveFileDialog
        {
            Title = "転送マクロを保存",
            Filter = "TTLマクロ (*.ttl)|*.ttl",
            DefaultExt = ".ttl",
            FileName = "transfer.ttl",
        };
        return dlg.ShowDialog(System.Windows.Window.GetWindow(this)) == true ? dlg.FileName : null;
    }

    private void OnSave(object sender, RoutedEventArgs e)
    {
        var path = AskSavePath();
        if (path == null) return;
        try
        {
            File.WriteAllText(path, BuildMacro());
            Host?.SetStatus("保存しました: " + path);
        }
        catch (Exception ex)
        {
            Host?.ShowError("保存に失敗しました。", ex);
        }
    }

    private void OnRun(object sender, RoutedEventArgs e)
    {
        if (Host == null) return;
        var path = AskSavePath();
        if (path == null) return;
        try
        {
            File.WriteAllText(path, BuildMacro());
            TeraTermLauncher.RunMacro(Host.Settings.TtpMacroPath, path);
            Host.SetStatus("転送マクロを実行しました: " + path);
        }
        catch (Exception ex)
        {
            Host.ShowError("実行に失敗しました。", ex);
        }
    }

    private static string Quote(string s) =>
        "'" + (s ?? "").Replace("'", "' #39 '") + "'";
}
