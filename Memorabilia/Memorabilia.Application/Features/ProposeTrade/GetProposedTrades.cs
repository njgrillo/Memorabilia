namespace Memorabilia.Application.Features.ProposeTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetProposedTrades() : IQuery<Entity.ProposeTrade[]>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IProposeTradeRepository proposeTradeRepository) 
        : QueryHandler<GetProposedTrades, Entity.ProposeTrade[]>
    {
        protected override async Task<Entity.ProposeTrade[]> Handle(GetProposedTrades query)
            => (await proposeTradeRepository.GetAll(applicationStateService.CurrentUser.Id))
                   .OrderByDescending(proposeTrade => proposeTrade.ProposedDate)
                   .ToArray();
    }
}
