namespace TeraTermUiTool.Models;

public enum Protocol
{
    Ssh2,
    Telnet,
    Serial,
}

public enum AuthMethod
{
    Password,
    PublicKey,
    KeyboardInteractive,
}

public class ConnectionProfile
{
    public string Name { get; set; } = "";
    public string Host { get; set; } = "";
    public int Port { get; set; } = 22;
    public Protocol Protocol { get; set; } = Protocol.Ssh2;
    public string User { get; set; } = "";
    public AuthMethod Auth { get; set; } = AuthMethod.Password;
    public string KeyFile { get; set; } = "";
    public bool SavePassword { get; set; }
    public string EncryptedPassword { get; set; } = "";
    public string SerialPort { get; set; } = "COM1";
    public int BaudRate { get; set; } = 9600;
}
