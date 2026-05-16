using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using TeraTermUiTool.Services;

namespace TeraTermUiTool.Views;

public partial class SettingsView : UserControl
{
    public MainWindow? Host { get; set; }

    public SettingsView()
    {
        InitializeComponent();
    }

    public void Reload()
    {
        if (Host == null) return;
        TermBox.Text = Host.Settings.TeraTermPath;
        MacroBox.Text = Host.Settings.TtpMacroPath;
    }

    private void OnBrowseTerm(object sender, RoutedEventArgs e)
    {
        var dlg = new OpenFileDialog { Title = "ttermpro.exe を選択", Filter = "実行ファイル (*.exe)|*.exe" };
        if (dlg.ShowDialog(System.Windows.Window.GetWindow(this)) == true) TermBox.Text = dlg.FileName;
    }

    private void OnBrowseMacro(object sender, RoutedEventArgs e)
    {
        var dlg = new OpenFileDialog { Title = "ttpmacro.exe を選択", Filter = "実行ファイル (*.exe)|*.exe" };
        if (dlg.ShowDialog(System.Windows.Window.GetWindow(this)) == true) MacroBox.Text = dlg.FileName;
    }

    private void OnAutoDetect(object sender, RoutedEventArgs e)
    {
        if (Host == null) return;
        Host.Settings.TeraTermPath = "";
        Host.Settings.TtpMacroPath = "";
        var detected = SettingsStore.Load();
        Host.Settings.TeraTermPath = detected.TeraTermPath;
        Host.Settings.TtpMacroPath = detected.TtpMacroPath;
        Reload();
        Host.SetStatus("自動検出を実行しました");
    }

    private void OnSave(object sender, RoutedEventArgs e)
    {
        if (Host == null) return;
        Host.Settings.TeraTermPath = TermBox.Text.Trim();
        Host.Settings.TtpMacroPath = MacroBox.Text.Trim();
        Host.SaveSettings();
        Host.SetStatus("設定を保存しました");
    }
}
