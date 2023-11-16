namespace Memorabilia.Application.Hangfire.Jobs.ProposedTrades;

[HangfireJob]
public class ProposedTradeExpiredJob(IMediator mediator,
                                     IOptions<ProposedTradeExpiredJobOption> options) 
    : HangfireJob<ProposedTradeExpiredJobOption>(options)
{
    public override async Task Process()
    {
        await mediator.Send(new ProcessExpiredProposedTrades());
    }

    public override Task DisposeJob()
        => Task.CompletedTask;
}
