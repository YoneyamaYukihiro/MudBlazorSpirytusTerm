using System;
using System.IO;
using System.Text.Json;
using TeraTermUiTool.Models;

namespace TeraTermUiTool.Services;

public static class SettingsStore
{
    private static readonly string Dir =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeraTermUiTool");

    private static readonly string SettingsPath = Path.Combine(Dir, "settings.json");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
    };

    public static AppSettings Load()
    {
        try
        {
            if (!File.Exists(SettingsPath)) return AutoDetect(new AppSettings());
            var json = File.ReadAllText(SettingsPath);
            var s = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
            return AutoDetect(s);
        }
        catch
        {
            return AutoDetect(new AppSettings());
        }
    }

    public static void Save(AppSettings settings)
    {
        Directory.CreateDirectory(Dir);
        var json = JsonSerializer.Serialize(settings, JsonOptions);
        File.WriteAllText(SettingsPath, json);
    }

    private static AppSettings AutoDetect(AppSettings s)
    {
        if (string.IsNullOrWhiteSpace(s.TeraTermPath))
        {
            foreach (var candidate in EnumerateTeraTermCandidates("ttermpro.exe"))
            {
                if (File.Exists(candidate)) { s.TeraTermPath = candidate; break; }
            }
        }
        if (string.IsNullOrWhiteSpace(s.TtpMacroPath))
        {
            foreach (var candidate in EnumerateTeraTermCandidates("ttpmacro.exe"))
            {
                if (File.Exists(candidate)) { s.TtpMacroPath = candidate; break; }
            }
        }
        return s;
    }

    private static System.Collections.Generic.IEnumerable<string> EnumerateTeraTermCandidates(string fileName)
    {
        var roots = new[]
        {
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
        };
        foreach (var root in roots)
        {
            if (string.IsNullOrEmpty(root)) continue;
            foreach (var folder in new[] { "teraterm5", "teraterm" })
            {
                yield return Path.Combine(root, folder, fileName);
            }
        }
    }
}
