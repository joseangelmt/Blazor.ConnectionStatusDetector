using Microsoft.JSInterop;

namespace Blazor.ConnectionStatusDetector;

public class ConnectionStatusDetectorService : IConnectionStatusDetectorService, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;

    public event EventHandler<bool>? ConnectionStatusChanged;
    public bool IsOnline { get; private set; }

    public ConnectionStatusDetectorService(IJSRuntime runtime)
    {
        _jsRuntime = runtime;

        Task.Run(async () =>
        {
            await _jsRuntime.InvokeVoidAsync("Connection.Initialize", DotNetObjectReference.Create(this));
        });
    }

    public async ValueTask DisposeAsync() => await _jsRuntime.InvokeVoidAsync("Connection.Dispose");

    [JSInvokable("Connection.StatusChanged")]
    public void OnConnectionStatusChanged(bool isOnline)
    {
        IsOnline = isOnline;
        
        if (IsOnline != isOnline)
        {
            IsOnline = isOnline;
        }

        ConnectionStatusChanged?.Invoke(this, isOnline);
    }
}