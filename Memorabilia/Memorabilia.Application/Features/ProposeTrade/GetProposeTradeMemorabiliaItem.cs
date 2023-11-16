namespace Memorabilia.Application.Features.ProposeTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetProposeTradeMemorabiliaItem(int MemorabiliaId)
    : IQuery<Entity.Memorabilia>
{
    public class Handler(ISiteMemorabiliaRepository memorabiliaRepository) 
        : QueryHandler<GetProposeTradeMemorabiliaItem, Entity.Memorabilia>
    {
        protected override async Task<Entity.Memorabilia> Handle(GetProposeTradeMemorabiliaItem query)
            => await memorabiliaRepository.Get(query.MemorabiliaId);
    }
}
