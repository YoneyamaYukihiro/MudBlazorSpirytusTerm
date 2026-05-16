using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using TeraTermUiTool.Models;
using TeraTermUiTool.Services;

namespace TeraTermUiTool.Views;

public partial class MacroBuilderView : UserControl
{
    public MainWindow? Host { get; set; }
    private readonly ObservableCollection<MacroStep> _steps = new();
    private MacroStep? _selected;
    private bool _suppress;

    public MacroBuilderView()
    {
        InitializeComponent();
        StepList.ItemsSource = _steps;
    }

    private void Add(MacroAction action, string arg1 = "", string arg2 = "")
    {
        var step = new MacroStep { Action = action, Argument1 = arg1, Argument2 = arg2 };
        _steps.Add(step);
        StepList.SelectedItem = step;
        RefreshPreview();
    }

    private void OnAddConnect(object s, RoutedEventArgs e) => Add(MacroAction.Connect, "myhost.example.com /ssh /2 /auth=password /user=USER /passwd=PASS");
    private void OnAddSendLn(object s, RoutedEventArgs e) => Add(MacroAction.SendLine, "ls -la");
    private void OnAddSend(object s, RoutedEventArgs e) => Add(MacroAction.Send, "y");
    private void OnAddWait(object s, RoutedEventArgs e) => Add(MacroAction.Wait, "$ ");
    private void OnAddWaitRegex(object s, RoutedEventArgs e) => Add(MacroAction.WaitRegex, @"[$#] $");
    private void OnAddPause(object s, RoutedEventArgs e) => Add(MacroAction.Pause, "1");
    private void OnAddMPause(object s, RoutedEventArgs e) => Add(MacroAction.MPause, "500");
    private void OnAddLogOpen(object s, RoutedEventArgs e) => Add(MacroAction.LogOpen, @"C:\temp\session.log", "append");
    private void OnAddLogClose(object s, RoutedEventArgs e) => Add(MacroAction.LogClose);
    private void OnAddDisconnect(object s, RoutedEventArgs e) => Add(MacroAction.Disconnect);
    private void OnAddComment(object s, RoutedEventArgs e) => Add(MacroAction.Comment, "ここにメモを書く");

    private void OnStepSelected(object sender, SelectionChangedEventArgs e)
    {
        _selected = StepList.SelectedItem as MacroStep;
        _suppress = true;
        try
        {
            if (_selected == null)
            {
                Arg1Box.Text = "";
                Arg2Box.Text = "";
                Arg2Box.Visibility = Visibility.Collapsed;
                Arg2Label.Visibility = Visibility.Collapsed;
                return;
            }
            Arg1Label.Content = _selected.Arg1Label;
            Arg1Box.Text = _selected.Argument1;
            Arg2Label.Content = _selected.Arg2Label;
            Arg2Box.Text = _selected.Argument2;
            var show2 = _selected.Arg2Visible;
            Arg2Box.Visibility = show2 ? Visibility.Visible : Visibility.Collapsed;
            Arg2Label.Visibility = show2 ? Visibility.Visible : Visibility.Collapsed;
        }
        finally { _suppress = false; }
    }

    private void OnArg1Changed(object sender, TextChangedEventArgs e)
    {
        if (_suppress || _selected == null) return;
        _selected.Argument1 = Arg1Box.Text;
        StepList.Items.Refresh();
        RefreshPreview();
    }

    private void OnArg2Changed(object sender, TextChangedEventArgs e)
    {
        if (_suppress || _selected == null) return;
        _selected.Argument2 = Arg2Box.Text;
        StepList.Items.Refresh();
        RefreshPreview();
    }

    private void OnMoveUp(object sender, RoutedEventArgs e)
    {
        var idx = StepList.SelectedIndex;
        if (idx <= 0) return;
        var item = _steps[idx];
        _steps.RemoveAt(idx);
        _steps.Insert(idx - 1, item);
        StepList.SelectedIndex = idx - 1;
        RefreshPreview();
    }

    private void OnMoveDown(object sender, RoutedEventArgs e)
    {
        var idx = StepList.SelectedIndex;
        if (idx < 0 || idx >= _steps.Count - 1) return;
        var item = _steps[idx];
        _steps.RemoveAt(idx);
        _steps.Insert(idx + 1, item);
        StepList.SelectedIndex = idx + 1;
        RefreshPreview();
    }

    private void OnDuplicate(object sender, RoutedEventArgs e)
    {
        if (StepList.SelectedItem is not MacroStep src) return;
        var copy = new MacroStep
        {
            Action = src.Action,
            Argument1 = src.Argument1,
            Argument2 = src.Argument2,
        };
        var idx = StepList.SelectedIndex + 1;
        _steps.Insert(idx, copy);
        StepList.SelectedIndex = idx;
        RefreshPreview();
    }

    private void OnDeleteStep(object sender, RoutedEventArgs e)
    {
        if (StepList.SelectedItem is not MacroStep s) return;
        _steps.Remove(s);
        RefreshPreview();
    }

    private void OnClear(object sender, RoutedEventArgs e)
    {
        if (_steps.Count == 0) return;
        if (MessageBox.Show("全ステップを削除しますか？", "確認",
                MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;
        _steps.Clear();
        RefreshPreview();
    }

    private void OnRefreshPreview(object sender, RoutedEventArgs e) => RefreshPreview();

    private void RefreshPreview()
    {
        PreviewBox.Text = MacroGenerator.Generate(_steps);
    }

    private void OnSaveMacro(object sender, RoutedEventArgs e)
    {
        var path = AskMacroPath();
        if (path == null) return;
        try
        {
            File.WriteAllText(path, MacroGenerator.Generate(_steps));
            Host?.SetStatus($"マクロを保存しました: {path}");
        }
        catch (Exception ex)
        {
            Host?.ShowError("マクロの保存に失敗しました。", ex);
        }
    }

    private void OnRunMacro(object sender, RoutedEventArgs e)
    {
        if (Host == null) return;
        var path = AskMacroPath();
        if (path == null) return;
        try
        {
            File.WriteAllText(path, MacroGenerator.Generate(_steps));
            TeraTermLauncher.RunMacro(Host.Settings.TtpMacroPath, path);
            Host.SetStatus($"マクロを実行しました: {path}");
        }
        catch (Exception ex)
        {
            Host.ShowError("マクロの実行に失敗しました。", ex);
        }
    }

    private string? AskMacroPath()
    {
        var dlg = new SaveFileDialog
        {
            Title = "マクロを保存",
            Filter = "TTLマクロ (*.ttl)|*.ttl|テキスト (*.txt)|*.txt",
            DefaultExt = ".ttl",
            FileName = "macro.ttl",
        };
        return dlg.ShowDialog(System.Windows.Window.GetWindow(this)) == true ? dlg.FileName : null;
    }
}
