namespace Memorabilia.Application.Features.Offer;

public record ProcessExpiredOffers()
     : ICommand
{
    public class Handler : CommandHandler<ProcessExpiredOffers>
    {
        private readonly IOfferRepository _offerRepository;

        public Handler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        protected override async Task Handle(ProcessExpiredOffers command)
        {
            Entity.Offer[] expiredOffers
                = await _offerRepository.GetAllExpired();

            if (!expiredOffers.Any())
                return;

            foreach (Entity.Offer offer in expiredOffers)
            {
                offer.SetStatus(Constant.OfferStatusType.Expired);

                await _offerRepository.Update(offer);
            }
        }
    }
}
