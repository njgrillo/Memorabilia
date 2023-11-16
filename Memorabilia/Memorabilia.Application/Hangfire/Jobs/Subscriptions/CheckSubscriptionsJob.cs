namespace Memorabilia.Application.Hangfire.Jobs.Subscriptions;

[HangfireJob]
public class CheckSubscriptionsJob(IMediator mediator,
                                   IOptions<CheckSubscriptionsJobOption> options)
    : HangfireJob<CheckSubscriptionsJobOption>(options)
{
    public override async Task Process()
    {
        await mediator.Send(new CheckActiveSubscriptions());
        await mediator.Send(new ProcessExpiredSubscriptions());
    }

    public override Task DisposeJob()
        => Task.CompletedTask;
}
