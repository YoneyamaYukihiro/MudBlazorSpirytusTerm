using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace MudBlazorSpirytusTerm.Services;

public sealed class ActiveMqMessageClient : ITfMessageClient, IDisposable
{
    private readonly string _brokerUri;
    private readonly string _userName;
    private readonly string _password;
    private readonly int _timeoutMs;
    private readonly ILogger<ActiveMqMessageClient> _logger;

    private IConnection? _connection;

    public bool IsAvailable { get; private set; }
    public string? LastError { get; private set; }

    public ActiveMqMessageClient(IConfiguration configuration, ILogger<ActiveMqMessageClient> logger)
    {
        _logger = logger;
        _brokerUri = configuration["ActiveMq:BrokerUri"] ?? "activemq:tcp://localhost:61616";
        _userName = configuration["ActiveMq:UserName"] ?? string.Empty;
        _password = configuration["ActiveMq:Password"] ?? string.Empty;
        _timeoutMs = int.TryParse(configuration["ActiveMq:TimeoutMs"], out var v) && v > 0 ? v : 15000;

        try
        {
            var factory = new ConnectionFactory(_brokerUri);
            _connection = string.IsNullOrEmpty(_userName)
                ? factory.CreateConnection()
                : factory.CreateConnection(_userName, _password);
            _connection.Start();
            IsAvailable = true;
            _logger.LogInformation("ActiveMQ connected: {BrokerUri}", _brokerUri);
        }
        catch (Exception ex)
        {
            LastError = ex.Message;
            IsAvailable = false;
            _logger.LogError(ex, "Failed to connect to ActiveMQ broker: {BrokerUri}", _brokerUri);
        }
    }

    public async Task<string> SendMessageAsync(string subject, string requestText, CancellationToken cancellationToken = default)
    {
        if (!IsAvailable || _connection is null)
        {
            return $"ActiveMQ is not available. {LastError}";
        }

        var sendSubject = subject?.Trim() ?? string.Empty;
        if (sendSubject.Length == 0)
        {
            return "ERR_MSG=\"subject is empty\" RET=\"1\"";
        }

        try
        {
            _logger.LogInformation("ActiveMQ SendMessageAsync subject={Subject}", sendSubject);

            var replyText = await Task.Run(() =>
            {
                using var session = _connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
                var destination = session.GetQueue(sendSubject);
                using var producer = session.CreateProducer(destination);
                using var tempQueue = session.CreateTemporaryQueue();
                using var consumer = session.CreateConsumer(tempQueue);

                var request = session.CreateTextMessage(requestText ?? string.Empty);
                request.NMSReplyTo = tempQueue;
                request.NMSCorrelationID = Guid.NewGuid().ToString();
                producer.Send(request);

                var reply = consumer.Receive(TimeSpan.FromMilliseconds(_timeoutMs));
                if (reply is ITextMessage textReply)
                {
                    return textReply.Text ?? string.Empty;
                }

                return $"ERR_MSG=\"activemq sendRequest timeout({_timeoutMs}ms)\" RET=\"1\"";
            }, cancellationToken);

            return replyText;
        }
        catch (OperationCanceledException)
        {
            return $"ERR_MSG=\"activemq sendRequest cancelled\" RET=\"1\"";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ActiveMQ SendMessageAsync error subject={Subject}", sendSubject);
            return ex.ToString();
        }
    }

    public void Dispose()
    {
        try
        {
            _connection?.Stop();
            _connection?.Close();
            _connection?.Dispose();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "ActiveMQ connection dispose error.");
        }
        _connection = null;
    }
}
