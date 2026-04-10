namespace MudBlazorSpirytusTerm.Services;

public interface ITfMessageClient
{
    bool IsAvailable { get; }
    string? LastError { get; }
    Task<string> SendMessageAsync(string subject, string requestText, CancellationToken cancellationToken = default);
}
