namespace Memorabilia.Application.Features.Offer;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetOffer(int Id) : IQuery<Entity.Offer>
{
    public class Handler : QueryHandler<GetOffer, Entity.Offer>
    {
        private readonly IOfferRepository _offerRepository;

        public Handler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        protected override async Task<Entity.Offer> Handle(GetOffer query)
            => await _offerRepository.Get(query.Id);
    }
}
