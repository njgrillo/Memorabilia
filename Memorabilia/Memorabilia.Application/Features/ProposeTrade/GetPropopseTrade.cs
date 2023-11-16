namespace Memorabilia.Application.Features.ProposeTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetPropopseTrade(int Id) : IQuery<Entity.ProposeTrade>
{
    public class Handler(IProposeTradeRepository proposeTradeRepository) 
        : QueryHandler<GetPropopseTrade, Entity.ProposeTrade>
    {
        protected override async Task<Entity.ProposeTrade> Handle(GetPropopseTrade query)
            => await proposeTradeRepository.Get(query.Id);
    }
}
