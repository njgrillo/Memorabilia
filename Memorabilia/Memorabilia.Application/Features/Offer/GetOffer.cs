namespace Memorabilia.Application.Features.Offer;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetOffer(int Id) : IQuery<Entity.Offer>
{
    public class Handler(IOfferRepository offerRepository) 
        : QueryHandler<GetOffer, Entity.Offer>
    {
        protected override async Task<Entity.Offer> Handle(GetOffer query)
            => await offerRepository.Get(query.Id);
    }
}
