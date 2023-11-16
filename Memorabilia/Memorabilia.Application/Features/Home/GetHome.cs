using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Home;

public record GetHome() : IQuery<HomeModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IOfferRepository offerRepository,
                         IProposeTradeRepository proposeTradeRepository) 
        : QueryHandler<GetHome, HomeModel>
    {
        protected override async Task<HomeModel> Handle(GetHome query)
        {
            int userId = applicationStateService.CurrentUser.Id;            

            Entity.ProposeTrade[] acceptedProposeTrades
                = await proposeTradeRepository.GetAllAccepted(userId);

            Entity.ProposeTrade[] pendingProposeTrades
                = await proposeTradeRepository.GetAllOpen(userId);

            Entity.Offer[] acceptedOffers
                = await offerRepository.GetAllAccepted(userId);

            Entity.Offer[] pendingOffers
                = await offerRepository.GetAllOpen(userId);

            return new HomeModel(userId, pendingProposeTrades, acceptedProposeTrades, pendingOffers, acceptedOffers);
        }
    }
}
