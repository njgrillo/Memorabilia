namespace Memorabilia.Application.Hangfire.Jobs.Offers;

public class OfferExpiredJobOption 
    : HangfireJobOption<OfferExpiredJobOption>
{
    public override OfferExpiredJobOption Value
        => this;
}
