namespace Memorabilia.Application.Hangfire.Jobs.ProposedTrades;

[HangfireJob]
public class ProposedTradeExpiredJob : HangfireJob<ProposedTradeExpiredJobOption>
{
    private readonly IMediator _mediator;

    public ProposedTradeExpiredJob(IMediator mediator,
                                   IOptions<ProposedTradeExpiredJobOption> options)
        : base(options) 
    {
        _mediator = mediator;
    }

    public override async Task Process()
    {
        await _mediator.Send(new ProcessExpiredProposedTrades());
    }

    public override Task DisposeJob()
    {
        return Task.CompletedTask;
    }
}
