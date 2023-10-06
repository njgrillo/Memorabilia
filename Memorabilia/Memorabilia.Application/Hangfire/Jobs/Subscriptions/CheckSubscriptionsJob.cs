namespace Memorabilia.Application.Hangfire.Jobs.Subscriptions;

[HangfireJob]
public class CheckSubscriptionsJob
    : HangfireJob<CheckSubscriptionsJobOption>
{
    private readonly IMediator _mediator;

    public CheckSubscriptionsJob(IMediator mediator,
                                 IOptions<CheckSubscriptionsJobOption> options)
        : base(options)
    {
        _mediator = mediator;
    }

    public override async Task Process()
    {
        await _mediator.Send(new CheckActiveSubscriptions());
        await _mediator.Send(new ProcessExpiredSubscriptions());
    }

    public override Task DisposeJob()
    {
        return Task.CompletedTask;
    }
}
