namespace Memorabilia.Application.Features.Services.Interfaces;

public interface IHangfireService
{
    void Dispose();

    Task StartAsync(CancellationToken cancellationToken);

    Task StopAsync(CancellationToken cancellationToken);
}
