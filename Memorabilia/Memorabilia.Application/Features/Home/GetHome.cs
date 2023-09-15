namespace Memorabilia.Application.Features.Home;

public record GetHome() : IQuery<HomeModel>
{
    public class Handler : QueryHandler<GetHome, HomeModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IOfferRepository _offerRepository;
        private readonly IProposeTradeRepository _proposeTradeRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IOfferRepository offerRepository,
                       IProposeTradeRepository proposeTradeRepository)
        {           
            _applicationStateService = applicationStateService;
            _offerRepository = offerRepository;
            _proposeTradeRepository = proposeTradeRepository;
        }

        protected override async Task<HomeModel> Handle(GetHome query)
        {
            int userId = _applicationStateService.CurrentUser.Id;            

            Entity.ProposeTrade[] acceptedProposeTrades
                = await _proposeTradeRepository.GetAllAccepted(userId);

            Entity.ProposeTrade[] pendingProposeTrades
                = await _proposeTradeRepository.GetAllOpen(userId);

            Entity.Offer[] acceptedOffers
                = await _offerRepository.GetAllAccepted(userId);

            Entity.Offer[] pendingOffers
                = await _offerRepository.GetAllOpen(userId);

            return new HomeModel(userId, pendingProposeTrades, acceptedProposeTrades, pendingOffers, acceptedOffers);
        }
    }
}
