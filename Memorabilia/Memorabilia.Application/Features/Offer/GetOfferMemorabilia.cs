namespace Memorabilia.Application.Features.Offer;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetOfferMemorabilia(int MemorabiliaId)
    : IQuery<Entity.Memorabilia>
{
    public class Handler(ISiteMemorabiliaRepository memorabiliaRepository) 
        : QueryHandler<GetOfferMemorabilia, Entity.Memorabilia>
    {
        protected override async Task<Entity.Memorabilia> Handle(GetOfferMemorabilia query)
            => await memorabiliaRepository.Get(query.MemorabiliaId);
    }
}
