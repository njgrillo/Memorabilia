namespace Memorabilia.Application.Hangfire.Jobs.Offers;

[HangfireJob]
public class OfferExpiredJob(IMediator mediator,
                             IOptions<OfferExpiredJobOption> options) 
    : HangfireJob<OfferExpiredJobOption>(options)
{
    public override async Task Process()
    {
        await mediator.Send(new ProcessExpiredOffers());
    }

    public override Task DisposeJob()
        => Task.CompletedTask;
}
