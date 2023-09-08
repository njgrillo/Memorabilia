namespace Memorabilia.Application.Features.ProposeTrade;

public record GetProposedTrades() : IQuery<Entity.ProposeTrade[]>
{
    public class Handler : QueryHandler<GetProposedTrades, Entity.ProposeTrade[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IProposeTradeRepository _proposeTradeRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IProposeTradeRepository proposeTradeRepository)
        {
            _applicationStateService = applicationStateService;
            _proposeTradeRepository = proposeTradeRepository;            
        }

        protected override async Task<Entity.ProposeTrade[]> Handle(GetProposedTrades query)
            => (await _proposeTradeRepository.GetAll(_applicationStateService.CurrentUser.Id))
                   .OrderByDescending(proposeTrade => proposeTrade.ProposedDate)
                   .ToArray();
    }
}
