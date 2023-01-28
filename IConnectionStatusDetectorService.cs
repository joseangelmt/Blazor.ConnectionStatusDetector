namespace Blazor.ConnectionStatusDetector;

public interface IConnectionStatusDetectorService
{
    event EventHandler<bool>? ConnectionStatusChanged;
    bool IsOnline { get; }
}