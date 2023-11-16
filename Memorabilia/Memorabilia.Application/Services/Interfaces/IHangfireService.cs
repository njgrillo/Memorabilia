namespace Memorabilia.Application.Services.Interfaces;

public interface IHangfireService
{
    void Dispose();

    Task StartAsync(CancellationToken cancellationToken);

    Task StopAsync(CancellationToken cancellationToken);
}
