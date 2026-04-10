using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Microsoft.Extensions.Options;

namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// TFLib の TfBase に相当するサービス。
/// ActiveMQ を使って Request / Reply パターンで通信する。
///
/// VBソース互換の呼び出し例:
///   var req = new TfMsg();
///   req.AddString(Tags.MsgVer, "12.01");
///   req.AddString(Tags.SbId, sbId);
///   var ans = await _mq.SendRequestAsync(MsgIds.LotList, req);
///   var ret = ans.GetString(Tags.Ret);
/// </summary>
public sealed class SpirytusMqService : IDisposable
{
    private readonly ActiveMqOptions _opts;
    private readonly ILogger<SpirytusMqService> _logger;

    private IConnectionFactory? _factory;
    private IConnection?        _connection;
    private Apache.NMS.ISession? _session;
    private readonly SemaphoreSlim _lock = new(1, 1);
    private bool _disposed;

    public SpirytusMqService(IOptions<ActiveMqOptions> opts, ILogger<SpirytusMqService> logger)
    {
        _opts   = opts.Value;
        _logger = logger;
    }

    // ──────────────────────────────────────────────────────────────
    // 公開 API
    // ──────────────────────────────────────────────────────────────

    /// <summary>
    /// VBソースの pTerm.sendRequest(msgId, lrMsg, laMsg) に相当する。
    /// msgId の Queue にリクエストを送信し、Reply Queue からレスポンスを受信して返す。
    /// </summary>
    /// <param name="msgId">メッセージID（例: "lot.list____"）</param>
    /// <param name="request">送信メッセージ</param>
    /// <param name="ct">キャンセルトークン</param>
    /// <returns>受信メッセージ</returns>
    public async Task<TfMsg> SendRequestAsync(string msgId, TfMsg request,
                                              CancellationToken ct = default)
    {
        await EnsureConnectedAsync(ct);

        var session = _session!;

        // 一時 Reply キューを作成
        var replyDest = await Task.Run(() => session.CreateTemporaryQueue(), ct);
        var requestDest = await Task.Run(() => session.GetQueue(msgId), ct);

        try
        {
            using var producer = await Task.Run(() => session.CreateProducer(requestDest), ct);
            using var consumer = await Task.Run(() => session.CreateConsumer(replyDest), ct);

            // リクエストメッセージ送信
            var textMsg = await Task.Run(() =>
            {
                var m = session.CreateTextMessage(request.ToXml());
                m.NMSReplyTo        = replyDest;
                m.NMSTimeToLive     = TimeSpan.FromMilliseconds(_opts.TimeoutMs);
                m.NMSDeliveryMode   = MsgDeliveryMode.NonPersistent;
                return m;
            }, ct);

            _logger.LogDebug("→ SendRequest [{MsgId}]: {Body}", msgId, textMsg.Text);
            await Task.Run(() => producer.Send(textMsg), ct);

            // レスポンス受信（タイムアウト付き）
            var timeout = TimeSpan.FromMilliseconds(_opts.TimeoutMs);
            var replyMsg = await Task.Run(() => consumer.Receive(timeout), ct)
                           as ITextMessage;

            if (replyMsg is null)
            {
                _logger.LogWarning("← No reply for [{MsgId}] within {Timeout}ms",
                                   msgId, _opts.TimeoutMs);
                // タイムアウト時はエラー応答として空メッセージを返す
                var timeout_ans = new TfMsg();
                timeout_ans.AddString(Tags.Ret, Tags.False);
                timeout_ans.AddString(Tags.ErrMsg,
                    $"タイムアウト：メッセージ[{msgId}]の通信中にタイムアウトが発生しました");
                return timeout_ans;
            }

            _logger.LogDebug("← Reply [{MsgId}]: {Body}", msgId, replyMsg.Text);
            return TfMsg.FromXml(replyMsg.Text);
        }
        finally
        {
            await Task.Run(() => replyDest.Delete(), ct);
        }
    }

    // ──────────────────────────────────────────────────────────────
    // 接続管理
    // ──────────────────────────────────────────────────────────────

    private async Task EnsureConnectedAsync(CancellationToken ct)
    {
        if (_session is not null) return;

        await _lock.WaitAsync(ct);
        try
        {
            if (_session is not null) return;

            _logger.LogInformation("ActiveMQ 接続開始: {Uri}", _opts.BrokerUri);

            _factory    = new ConnectionFactory(_opts.BrokerUri);
            _connection = string.IsNullOrEmpty(_opts.UserName)
                ? await Task.Run(() => _factory.CreateConnection(), ct)
                : await Task.Run(() => _factory.CreateConnection(_opts.UserName, _opts.Password), ct);

            _connection.ExceptionListener += ex =>
                _logger.LogError(ex, "ActiveMQ 接続エラー");

            await Task.Run(() => _connection.Start(), ct);
            _session = await Task.Run(
                () => _connection.CreateSession(AcknowledgementMode.AutoAcknowledge), ct);

            _logger.LogInformation("ActiveMQ 接続完了");
        }
        finally
        {
            _lock.Release();
        }
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;

        try { _session?.Close();    } catch { /* ignore */ }
        try { _connection?.Close(); } catch { /* ignore */ }
        _lock.Dispose();
    }
}
