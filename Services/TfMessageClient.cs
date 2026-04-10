using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.Versioning;
using Microsoft.VisualBasic;

namespace MudBlazorSpirytusTerm.Services;

[SupportedOSPlatform("windows")]
public sealed class TfMessageClient : ITfMessageClient, IDisposable
{
    private readonly BlockingCollection<WorkItem> _queue = new();
    private readonly Thread _staThread;
    private readonly string _iniPath;
    private readonly string _workingDirectory;
    private readonly int _timeoutMs;
    private readonly ILogger<TfMessageClient> _logger;

    private object? _act;

    public bool IsAvailable { get; private set; }
    public string? LastError { get; private set; }

    public TfMessageClient(IConfiguration configuration, ILogger<TfMessageClient> logger)
    {
        _logger = logger;
        _iniPath = configuration["Tf:IniPath"] ?? @"C:\ACT\nu\nu.ini";
        _workingDirectory = configuration["Tf:WorkingDirectory"] ?? @"C:\ACT\nu";
        _timeoutMs = int.TryParse(configuration["Tf:TimeoutMs"], out var v) && v > 0 ? v : 15000;

        _staThread = new Thread(StaWorker)
        {
            IsBackground = true,
            Name = "TfComStaThread"
        };
        _staThread.SetApartmentState(ApartmentState.STA);
        _staThread.Start();

        try
        {
            InvokeOnSta(() =>
            {
                _act = CreateComObject(["Tf.TfBase", "Tf.TfBase.1", "TFLib.TfBase"]);
                SetWorkingDirectory(_workingDirectory);
                TryInitCom(_act, _iniPath);
                return 0;
            });

            IsAvailable = true;
        }
        catch (Exception ex)
        {
            LastError = ex.Message;
            IsAvailable = false;
            _logger.LogError(ex, "Failed to initialize Tf COM.");
        }
    }

    public async Task<string> SendMessageAsync(string subject, string requestText, CancellationToken cancellationToken = default)
    {
        if (!IsAvailable || _act is null)
        {
            return $"TFLib is not available. {LastError}";
        }

        var sendSubject = subject?.Trim() ?? string.Empty;
        if (sendSubject.Length == 0)
        {
            return "ERR_MSG=\"subject is empty\" RET=\"1\"";
        }

        try
        {
            _logger.LogInformation("Tf SendMessageAsync subject={Subject}", sendSubject);
            var invokeTask = Task.Run(() => InvokeOnSta(() =>
            {
                object requestObj = CreateComObject(["Tf.TfMsg", "Tf.TfMsg.1", "TFLib.TfMsg"]);
                object replyObj = CreateComObject(["Tf.TfMsg", "Tf.TfMsg.1", "TFLib.TfMsg"]);

                Interaction.CallByName(requestObj, "clear", CallType.Method);
                Interaction.CallByName(replyObj, "clear", CallType.Method);
                Interaction.CallByName(requestObj, "set", CallType.Method, requestText ?? string.Empty);

                var args = new object?[] { sendSubject, requestObj, replyObj };
                var byRef = new ParameterModifier(3);
                byRef[1] = true;
                byRef[2] = true;

                _act.GetType().InvokeMember(
                    "sendRequest",
                    BindingFlags.InvokeMethod,
                    null,
                    _act,
                    args,
                    [byRef],
                    null,
                    null);

                requestObj = args[1] ?? requestObj;
                replyObj = args[2] ?? replyObj;
                return ReadReplyText(replyObj);
            }), cancellationToken);

            var finished = await Task.WhenAny(invokeTask, Task.Delay(_timeoutMs, cancellationToken));
            if (finished != invokeTask)
            {
                return $"ERR_MSG=\"tf sendRequest timeout({_timeoutMs}ms)\" RET=\"1\"";
            }

            return await invokeTask;
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    public void Dispose()
    {
        _queue.CompleteAdding();
    }

    private void StaWorker()
    {
        foreach (var item in _queue.GetConsumingEnumerable())
        {
            try
            {
                var value = item.Action();
                item.Tcs.SetResult(value);
            }
            catch (Exception ex)
            {
                item.Tcs.SetException(ex);
            }
        }
    }

    private T InvokeOnSta<T>(Func<T> action)
    {
        var work = new WorkItem(
            () => action()!,
            new TaskCompletionSource<object?>(TaskCreationOptions.RunContinuationsAsynchronously));

        _queue.Add(work);
        var result = work.Tcs.Task.GetAwaiter().GetResult();
        return (T)result!;
    }

    private static void TryInitCom(object act, string iniPath)
    {
        try
        {
            Interaction.CallByName(act, "init", CallType.Method);
            return;
        }
        catch
        {
        }

        try
        {
            Interaction.CallByName(act, "iniFileRead", CallType.Method, iniPath);
            Interaction.CallByName(act, "init", CallType.Method, iniPath);
            return;
        }
        catch
        {
        }

        Interaction.CallByName(act, "init", CallType.Method, iniPath);
    }

    private static void SetWorkingDirectory(string workingDirectory)
    {
        if (string.IsNullOrWhiteSpace(workingDirectory))
        {
            return;
        }

        if (Directory.Exists(workingDirectory))
        {
            Directory.SetCurrentDirectory(workingDirectory);
        }
    }

    private static object CreateComObject(IEnumerable<string> progIds)
    {
        foreach (var progId in progIds)
        {
            var type = Type.GetTypeFromProgID(progId);
            if (type is null)
            {
                continue;
            }

            var instance = Activator.CreateInstance(type);
            if (instance is not null)
            {
                return instance;
            }
        }

        throw new InvalidOperationException($"COM ProgID not found. Tried: {string.Join(", ", progIds)}");
    }

    private static string ReadReplyText(object replyObj)
    {
        var candidates = new List<string?>();

        try
        {
            candidates.Add(Convert.ToString(Interaction.CallByName(replyObj, "toString", CallType.Get)));
        }
        catch
        {
        }

        try
        {
            candidates.Add(Convert.ToString(Interaction.CallByName(replyObj, "toString", CallType.Method)));
        }
        catch
        {
        }

        try
        {
            candidates.Add(Convert.ToString(replyObj.GetType().InvokeMember("toString", BindingFlags.GetProperty, null, replyObj, null)));
        }
        catch
        {
        }

        foreach (var c in candidates)
        {
            if (!string.IsNullOrWhiteSpace(c) && c != "()")
            {
                return c;
            }
        }

        return candidates.FirstOrDefault(c => !string.IsNullOrWhiteSpace(c)) ?? string.Empty;
    }

    private sealed record WorkItem(Func<object?> Action, TaskCompletionSource<object?> Tcs);
}
