namespace Memorabilia.Application.Features.Offer;

public record ProcessExpiredOffers()
     : ICommand
{
    public class Handler(IOfferRepository offerRepository) 
        : CommandHandler<ProcessExpiredOffers>
    {
        protected override async Task Handle(ProcessExpiredOffers command)
        {
            Entity.Offer[] expiredOffers
                = await offerRepository.GetAllExpired();

            if (expiredOffers.IsNullOrEmpty())
                return;

            foreach (Entity.Offer offer in expiredOffers)
            {
                offer.SetStatus(Constant.OfferStatusType.Expired);

                await offerRepository.Update(offer);
            }
        }
    }
}
