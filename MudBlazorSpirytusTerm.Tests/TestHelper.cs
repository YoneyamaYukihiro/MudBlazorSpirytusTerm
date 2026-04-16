using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Tests;

/// <summary>
/// テスト共通ヘルパー。
/// ITfMessageClient の Mock 生成と IConfiguration / ILogger のスタブを提供する。
/// </summary>
public static class TestHelper
{
    /// <summary>テスト用デフォルト設定値</summary>
    private static readonly Dictionary<string, string?> DefaultSettings = new()
    {
        ["Spirytus:DefaultSbId"]    = "1A0",
        ["Spirytus:DefaultWpId"]    = "1AFP310CTS01",
        ["Spirytus:MenuFlowLoginId"] = "MENUFLOW",
        ["Spirytus:MenuToolLoginId"] = "MENUTOOL",
        ["Spirytus:MenuKind"]        = "A"
    };

    /// <summary>テスト用 IConfiguration を生成する。</summary>
    public static IConfiguration CreateConfig(Dictionary<string, string?>? overrides = null)
    {
        var settings = new Dictionary<string, string?>(DefaultSettings);
        if (overrides is not null)
        {
            foreach (var kv in overrides)
                settings[kv.Key] = kv.Value;
        }
        return new ConfigurationBuilder()
            .AddInMemoryCollection(settings)
            .Build();
    }

    /// <summary>NullLogger を生成する。</summary>
    public static ILogger<T> CreateLogger<T>() => NullLoggerFactory.Instance.CreateLogger<T>();

    /// <summary>
    /// 正常応答を返す ITfMessageClient の Mock を生成する。
    /// subject に対して responseText を返す。
    /// </summary>
    public static Mock<ITfMessageClient> CreateMock(string expectedSubject, string responseText)
    {
        var mock = new Mock<ITfMessageClient>();
        mock.SetupGet(m => m.IsAvailable).Returns(true);
        mock.Setup(m => m.SendMessageAsync(expectedSubject, It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(responseText);
        return mock;
    }

    /// <summary>
    /// SendMessageAsync 呼び出し時に例外を投げる Mock を生成する。
    /// </summary>
    public static Mock<ITfMessageClient> CreateMockThrows(string expectedSubject, Exception ex)
    {
        var mock = new Mock<ITfMessageClient>();
        mock.SetupGet(m => m.IsAvailable).Returns(true);
        mock.Setup(m => m.SendMessageAsync(expectedSubject, It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(ex);
        return mock;
    }

    /// <summary>
    /// 成功応答の TfMsg 文字列を構築するヘルパー。
    /// RET="0" を自動的に付加する。
    /// </summary>
    public static string BuildSuccessResponse(Action<TfMsg>? configure = null)
    {
        var msg = new TfMsg();
        msg.AddString(Tags.Ret, Tags.True);
        configure?.Invoke(msg);
        return msg.ToTfString();
    }

    /// <summary>
    /// 失敗応答の TfMsg 文字列を構築するヘルパー。
    /// RET="1" と ERR_MSG を付加する。
    /// </summary>
    public static string BuildErrorResponse(string errorMessage = "テストエラー")
    {
        var msg = new TfMsg();
        msg.AddString(Tags.Ret, Tags.False);
        msg.AddString(Tags.ErrMsg, errorMessage);
        return msg.ToTfString();
    }
}
