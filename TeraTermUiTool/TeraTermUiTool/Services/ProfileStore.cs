using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using TeraTermUiTool.Models;

namespace TeraTermUiTool.Services;

public static class ProfileStore
{
    private static readonly string Dir =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TeraTermUiTool");

    private static readonly string ProfilesPath = Path.Combine(Dir, "profiles.json");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
    };

    public static List<ConnectionProfile> Load()
    {
        try
        {
            if (!File.Exists(ProfilesPath)) return new List<ConnectionProfile>();
            var json = File.ReadAllText(ProfilesPath);
            return JsonSerializer.Deserialize<List<ConnectionProfile>>(json) ?? new List<ConnectionProfile>();
        }
        catch
        {
            return new List<ConnectionProfile>();
        }
    }

    public static void Save(IEnumerable<ConnectionProfile> profiles)
    {
        Directory.CreateDirectory(Dir);
        var json = JsonSerializer.Serialize(profiles, JsonOptions);
        File.WriteAllText(ProfilesPath, json);
    }

    public static string Protect(string plaintext)
    {
        if (string.IsNullOrEmpty(plaintext)) return "";
        var data = Encoding.UTF8.GetBytes(plaintext);
        var encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        return Convert.ToBase64String(encrypted);
    }

    public static string Unprotect(string base64)
    {
        if (string.IsNullOrEmpty(base64)) return "";
        try
        {
            var encrypted = Convert.FromBase64String(base64);
            var data = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(data);
        }
        catch
        {
            return "";
        }
    }
}
