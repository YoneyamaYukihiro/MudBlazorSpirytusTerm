namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// ActiveMQ 接続設定。appsettings.json の "ActiveMq" セクションにバインドする。
/// </summary>
public sealed class ActiveMqOptions
{
    public const string SectionName = "ActiveMq";

    /// <summary>ActiveMQ ブローカー URI 例: activemq:tcp://localhost:61616</summary>
    public string BrokerUri { get; set; } = "activemq:tcp://localhost:61616";

    /// <summary>接続ユーザ名</summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>接続パスワード</summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>送受信タイムアウト（ミリ秒）</summary>
    public int TimeoutMs { get; set; } = 30_000;
}
