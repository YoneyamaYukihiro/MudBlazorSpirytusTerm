namespace MudBlazorSpirytusTerm.Services;

public sealed class UnavailableTfMessageClient : ITfMessageClient
{
    public bool IsAvailable => false;
    public string? LastError => "TFLib is supported on Windows only.";

    public Task<string> SendMessageAsync(string subject, string requestText, CancellationToken cancellationToken = default)
    {
        return Task.FromResult("TFLib is supported on Windows only.");
    }
}
