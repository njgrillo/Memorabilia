using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Offer;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetOffers() : IQuery<Entity.Offer[]>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IOfferRepository offerRepository) 
        : QueryHandler<GetOffers, Entity.Offer[]>
    {
        protected override async Task<Entity.Offer[]> Handle(GetOffers query)
            => (await offerRepository.GetAll(applicationStateService.CurrentUser.Id))
                    .OrderByDescending(offer => offer.OfferDate)
                    .ToArray();
    }
}
