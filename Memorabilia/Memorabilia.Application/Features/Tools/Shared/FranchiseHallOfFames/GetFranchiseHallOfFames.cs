namespace Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;

public record GetFranchiseHallOfFames(int FranchiseId, Domain.Constants.SportLeagueLevel SportLeagueLevel) : IQuery<FranchiseHallOfFamesViewModel>
{
    public class Handler : QueryHandler<GetFranchiseHallOfFames, FranchiseHallOfFamesViewModel>
    {
        private readonly IFranchiseHallOfFameRepository _franchiseHallOfFameRepository;

        public Handler(IFranchiseHallOfFameRepository franchiseHallOfFameRepository)
        {
            _franchiseHallOfFameRepository = franchiseHallOfFameRepository;
        }

        protected override async Task<FranchiseHallOfFamesViewModel> Handle(GetFranchiseHallOfFames query)
        {
            return new FranchiseHallOfFamesViewModel(await _franchiseHallOfFameRepository.GetAll(query.FranchiseId), query.SportLeagueLevel)
            {
                FranchiseId = query.FranchiseId
            };
        }
    }
}
