namespace Memorabilia.Application.Hangfire;

public abstract class HangfireJob<TOption>
    : IDisposable where TOption : HangfireJobOption<TOption>
{
    private bool _hasDisposed;

    public TOption JobSettings { get; set; }

    public HangfireJob(IOptions<HangfireJobOption<TOption>> options)
    {
        JobSettings = options.Value.Value;
    }

    public abstract Task DisposeJob();

    public abstract Task Process();

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing)
    {
        if (_hasDisposed)
            return;

        if (disposing)
            DisposeJob();

        _hasDisposed = true;
    }
}
