namespace TeraTermUiTool.Models;

public class LogSettings
{
    public string LogPath { get; set; } = "";
    public bool Append { get; set; } = true;
    public bool Binary { get; set; }
    public bool Timestamp { get; set; } = true;
    public bool HideLogDialog { get; set; } = true;

    public bool IsEnabled => !string.IsNullOrWhiteSpace(LogPath);
}
