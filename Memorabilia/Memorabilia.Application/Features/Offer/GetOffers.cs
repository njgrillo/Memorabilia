namespace Memorabilia.Application.Features.Offer;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetOffers() : IQuery<Entity.Offer[]>
{
    public class Handler : QueryHandler<GetOffers, Entity.Offer[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IOfferRepository _offerRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IOfferRepository offerRepository)
        {
            _applicationStateService = applicationStateService;
            _offerRepository = offerRepository;
        }

        protected override async Task<Entity.Offer[]> Handle(GetOffers query)
            => (await _offerRepository.GetAll(_applicationStateService.CurrentUser.Id))
                    .OrderByDescending(offer => offer.OfferDate)
                    .ToArray();
    }
}
