namespace Memorabilia.Application.Features.Tools.Baseball.FranchiseHallOfFames;

public record GetFranchiseHallOfFames(int FranchiseId) : IQuery<FranchiseHallOfFamesViewModel>
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
            return new FranchiseHallOfFamesViewModel(await _franchiseHallOfFameRepository.GetAll(query.FranchiseId))
            {
                FranchiseId = query.FranchiseId
            };
        }
    }
}
