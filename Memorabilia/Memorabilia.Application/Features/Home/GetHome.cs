namespace Memorabilia.Application.Features.Home;

public record GetHome() : IQuery<HomeModel>
{
    public class Handler : QueryHandler<GetHome, HomeModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IProposeTradeRepository _proposeTradeRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IProposeTradeRepository proposeTradeRepository)
        {           
            _applicationStateService = applicationStateService;
            _proposeTradeRepository = proposeTradeRepository;
        }

        protected override async Task<HomeModel> Handle(GetHome query)
        {
            int userId = _applicationStateService.CurrentUser.Id;

            Entity.ProposeTrade[] pendingProposeTrades
                = await _proposeTradeRepository.GetAllOpen(userId);

            Entity.ProposeTrade[] acceptedProposeTrades
                = await _proposeTradeRepository.GetAllAccepted(userId);

            return new HomeModel(userId, pendingProposeTrades, acceptedProposeTrades);
        }
    }
}
