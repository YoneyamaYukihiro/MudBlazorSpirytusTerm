using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using TeraTermUiTool.Models;

namespace TeraTermUiTool.Services;

public static class TeraTermLauncher
{
    public static string BuildArguments(ConnectionProfile profile, string? password, LogSettings? log)
    {
        var args = new List<string>();

        switch (profile.Protocol)
        {
            case Protocol.Ssh2:
                if (!string.IsNullOrWhiteSpace(profile.Host))
                    args.Add(Quote($"{profile.Host}:{profile.Port}"));
                args.Add("/ssh");
                args.Add("/2");
                args.Add($"/auth={AuthSwitch(profile.Auth)}");
                if (!string.IsNullOrWhiteSpace(profile.User)) args.Add($"/user={profile.User}");
                if (!string.IsNullOrEmpty(password)) args.Add($"/passwd={Quote(password)}");
                if (profile.Auth == AuthMethod.PublicKey && !string.IsNullOrWhiteSpace(profile.KeyFile))
                    args.Add($"/keyfile={Quote(profile.KeyFile)}");
                break;

            case Protocol.Telnet:
                if (!string.IsNullOrWhiteSpace(profile.Host))
                    args.Add(Quote($"{profile.Host}:{profile.Port}"));
                args.Add("/T=1");
                break;

            case Protocol.Serial:
                args.Add($"/C={SerialPortNumber(profile.SerialPort)}");
                args.Add($"/BAUD={profile.BaudRate}");
                break;
        }

        if (log is { IsEnabled: true })
        {
            args.Add($"/L={Quote(log.LogPath)}");
            if (log.Append) args.Add("/LA=on");
            if (log.Binary) args.Add("/LB=on");
            if (log.Timestamp) args.Add("/LT=on");
            if (log.HideLogDialog) args.Add("/LD=off");
        }

        return string.Join(" ", args);
    }

    public static Process Launch(string teraTermExe, string arguments)
    {
        if (string.IsNullOrWhiteSpace(teraTermExe) || !File.Exists(teraTermExe))
            throw new FileNotFoundException("ttermpro.exe が見つかりません。設定タブで指定してください。", teraTermExe);

        var psi = new ProcessStartInfo
        {
            FileName = teraTermExe,
            Arguments = arguments,
            UseShellExecute = true,
            WorkingDirectory = Path.GetDirectoryName(teraTermExe) ?? Environment.CurrentDirectory,
        };
        return Process.Start(psi)
               ?? throw new InvalidOperationException("Tera Term の起動に失敗しました。");
    }

    public static Process RunMacro(string ttpMacroExe, string macroPath)
    {
        if (string.IsNullOrWhiteSpace(ttpMacroExe) || !File.Exists(ttpMacroExe))
            throw new FileNotFoundException("ttpmacro.exe が見つかりません。設定タブで指定してください。", ttpMacroExe);
        if (!File.Exists(macroPath))
            throw new FileNotFoundException("マクロファイルが存在しません。", macroPath);

        var psi = new ProcessStartInfo
        {
            FileName = ttpMacroExe,
            Arguments = Quote(macroPath),
            UseShellExecute = true,
            WorkingDirectory = Path.GetDirectoryName(ttpMacroExe) ?? Environment.CurrentDirectory,
        };
        return Process.Start(psi)
               ?? throw new InvalidOperationException("マクロの起動に失敗しました。");
    }

    private static string AuthSwitch(AuthMethod m) => m switch
    {
        AuthMethod.Password => "password",
        AuthMethod.PublicKey => "publickey",
        AuthMethod.KeyboardInteractive => "challenge",
        _ => "password",
    };

    private static int SerialPortNumber(string com)
    {
        var digits = new StringBuilder();
        foreach (var c in com ?? "") if (char.IsDigit(c)) digits.Append(c);
        return int.TryParse(digits.ToString(), out var n) && n > 0 ? n : 1;
    }

    private static string Quote(string s)
    {
        if (string.IsNullOrEmpty(s)) return "\"\"";
        if (s.IndexOfAny(new[] { ' ', '\t', '"' }) < 0) return s;
        return "\"" + s.Replace("\"", "\\\"") + "\"";
    }
}
