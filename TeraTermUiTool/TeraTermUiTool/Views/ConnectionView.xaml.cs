using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using TeraTermUiTool.Models;
using TeraTermUiTool.Services;

namespace TeraTermUiTool.Views;

public partial class ConnectionView : UserControl
{
    public MainWindow? Host { get; set; }

    private readonly ObservableCollection<ConnectionProfile> _profiles = new();
    private bool _suppressEvents;

    public ConnectionView()
    {
        InitializeComponent();
        ProfileList.ItemsSource = _profiles;
    }

    public void Reload()
    {
        _profiles.Clear();
        foreach (var p in ProfileStore.Load()) _profiles.Add(p);

        if (_profiles.Count == 0)
        {
            _profiles.Add(new ConnectionProfile { Name = "新規プロファイル" });
        }
        ProfileList.SelectedIndex = 0;
    }

    private void OnProfileSelected(object sender, SelectionChangedEventArgs e)
    {
        if (ProfileList.SelectedItem is not ConnectionProfile p) return;
        _suppressEvents = true;
        try
        {
            NameBox.Text = p.Name;
            HostBox.Text = p.Host;
            PortBox.Text = p.Port.ToString();
            UserBox.Text = p.User;
            KeyFileBox.Text = p.KeyFile;
            ComPortBox.Text = p.SerialPort;
            BaudBox.Text = p.BaudRate.ToString();
            SavePasswordBox.IsChecked = p.SavePassword;
            PasswordBox.Password = p.SavePassword ? ProfileStore.Unprotect(p.EncryptedPassword) : "";
            SelectComboByTag(ProtocolBox, p.Protocol.ToString());
            SelectComboByTag(AuthBox, p.Auth.ToString());
        }
        finally { _suppressEvents = false; }

        UpdateProtocolVisibility();
        UpdateAuthVisibility();
    }

    private static void SelectComboByTag(ComboBox box, string tag)
    {
        foreach (var item in box.Items.OfType<ComboBoxItem>())
        {
            if ((item.Tag as string) == tag)
            {
                box.SelectedItem = item;
                return;
            }
        }
        box.SelectedIndex = 0;
    }

    private static string? SelectedTag(ComboBox box) =>
        (box.SelectedItem as ComboBoxItem)?.Tag as string;

    private void OnProtocolChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_suppressEvents) return;
        UpdateProtocolVisibility();

        var tag = SelectedTag(ProtocolBox);
        if (tag == "Ssh2") PortBox.Text = "22";
        else if (tag == "Telnet") PortBox.Text = "23";
    }

    private void OnAuthChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_suppressEvents) return;
        UpdateAuthVisibility();
    }

    private void UpdateProtocolVisibility()
    {
        if (SerialGroup == null) return;
        var tag = SelectedTag(ProtocolBox);
        SerialGroup.Visibility = tag == "Serial" ? Visibility.Visible : Visibility.Collapsed;
    }

    private void UpdateAuthVisibility()
    {
        if (KeyLabel == null) return;
        var tag = SelectedTag(AuthBox);
        var show = tag == "PublicKey";
        KeyLabel.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
        KeyFileBox.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
    }

    private void OnBrowseKey(object sender, RoutedEventArgs e)
    {
        var dlg = new OpenFileDialog
        {
            Title = "秘密鍵ファイルを選択",
            Filter = "全てのファイル (*.*)|*.*",
        };
        if (dlg.ShowDialog(System.Windows.Window.GetWindow(this)) == true)
        {
            KeyFileBox.Text = dlg.FileName;
        }
    }

    private void OnNewProfile(object sender, RoutedEventArgs e)
    {
        var p = new ConnectionProfile { Name = "新規プロファイル" };
        _profiles.Add(p);
        ProfileList.SelectedItem = p;
    }

    private void OnDeleteProfile(object sender, RoutedEventArgs e)
    {
        if (ProfileList.SelectedItem is not ConnectionProfile p) return;
        if (MessageBox.Show($"\"{p.Name}\" を削除しますか？", "確認",
                MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;
        _profiles.Remove(p);
        ProfileStore.Save(_profiles);
        Host?.SetStatus("削除しました");
        if (_profiles.Count > 0) ProfileList.SelectedIndex = 0;
    }

    private void OnSave(object sender, RoutedEventArgs e)
    {
        var p = CaptureForm();
        if (p == null) return;

        if (ProfileList.SelectedItem is ConnectionProfile current)
        {
            CopyTo(p, current);
        }
        else
        {
            _profiles.Add(p);
        }
        ProfileStore.Save(_profiles);
        ProfileList.Items.Refresh();
        Host?.SetStatus($"保存しました: {p.Name}");
    }

    private void OnConnect(object sender, RoutedEventArgs e)
    {
        var p = CaptureForm();
        if (p == null) return;
        if (Host == null) return;

        try
        {
            var password = PasswordBox.Password;
            var args = TeraTermLauncher.BuildArguments(p, password, Host.ActiveLog);
            TeraTermLauncher.Launch(Host.Settings.TeraTermPath, args);
            Host.SetStatus($"接続を開始しました: {p.Host}");
        }
        catch (Exception ex)
        {
            Host.ShowError("接続を開始できませんでした。", ex);
        }
    }

    private ConnectionProfile? CaptureForm()
    {
        if (!int.TryParse(PortBox.Text, out var port) || port <= 0 || port > 65535)
        {
            Host?.ShowError("ポート番号が不正です（1-65535）。");
            return null;
        }
        if (!int.TryParse(BaudBox.Text, out var baud) || baud <= 0)
        {
            baud = 9600;
        }

        var p = new ConnectionProfile
        {
            Name = string.IsNullOrWhiteSpace(NameBox.Text) ? HostBox.Text : NameBox.Text,
            Host = HostBox.Text.Trim(),
            Port = port,
            Protocol = Enum.TryParse<Protocol>(SelectedTag(ProtocolBox), out var pr) ? pr : Protocol.Ssh2,
            User = UserBox.Text.Trim(),
            Auth = Enum.TryParse<AuthMethod>(SelectedTag(AuthBox), out var au) ? au : AuthMethod.Password,
            KeyFile = KeyFileBox.Text.Trim(),
            SerialPort = ComPortBox.Text.Trim(),
            BaudRate = baud,
            SavePassword = SavePasswordBox.IsChecked == true,
        };
        p.EncryptedPassword = p.SavePassword ? ProfileStore.Protect(PasswordBox.Password) : "";
        return p;
    }

    private static void CopyTo(ConnectionProfile from, ConnectionProfile to)
    {
        to.Name = from.Name;
        to.Host = from.Host;
        to.Port = from.Port;
        to.Protocol = from.Protocol;
        to.User = from.User;
        to.Auth = from.Auth;
        to.KeyFile = from.KeyFile;
        to.SerialPort = from.SerialPort;
        to.BaudRate = from.BaudRate;
        to.SavePassword = from.SavePassword;
        to.EncryptedPassword = from.EncryptedPassword;
    }
}
