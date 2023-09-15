namespace Memorabilia.Application.Hangfire.Jobs.Offers;

[HangfireJob]
public class OfferExpiredJob : HangfireJob<OfferExpiredJobOption>
{
    private readonly IMediator _mediator;

    public OfferExpiredJob(IMediator mediator,
                           IOptions<OfferExpiredJobOption> options)
        : base(options)
    {
        _mediator = mediator;
    }

    public override async Task Process()
    {
        await _mediator.Send(new ProcessExpiredOffers());
    }

    public override Task DisposeJob()
    {
        return Task.CompletedTask;
    }
}
