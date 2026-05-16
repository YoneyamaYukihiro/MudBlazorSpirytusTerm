using System;
using System.Windows;
using TeraTermUiTool.Models;
using TeraTermUiTool.Services;

namespace TeraTermUiTool;

public partial class MainWindow : Window
{
    public AppSettings Settings { get; private set; } = SettingsStore.Load();
    public LogSettings ActiveLog { get; } = new();

    public MainWindow()
    {
        InitializeComponent();
        ConnectionTab.Host = this;
        MacroTab.Host = this;
        LogTab.Host = this;
        FileTransferTab.Host = this;
        SettingsTab.Host = this;

        ConnectionTab.Reload();
        SettingsTab.Reload();
        LogTab.Reload();
    }

    public void SetStatus(string text)
    {
        StatusText.Text = text;
    }

    public void ShowError(string message, Exception? ex = null)
    {
        var detail = ex == null ? message : $"{message}\n\n{ex.Message}";
        MessageBox.Show(this, detail, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        SetStatus("エラー: " + message);
    }

    public void SaveSettings()
    {
        SettingsStore.Save(Settings);
    }
}
