using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;

public record GetFranchiseHallOfFames(Franchise Franchise, Sport Sport) : IQuery<FranchiseHallOfFamesModel>
{
    public class Handler : QueryHandler<GetFranchiseHallOfFames, FranchiseHallOfFamesModel>
    {
        private readonly IFranchiseHallOfFameRepository _franchiseHallOfFameRepository;

        public Handler(IFranchiseHallOfFameRepository franchiseHallOfFameRepository)
        {
            _franchiseHallOfFameRepository = franchiseHallOfFameRepository;
        }

        protected override async Task<FranchiseHallOfFamesModel> Handle(GetFranchiseHallOfFames query)
        {
            return new FranchiseHallOfFamesModel(await _franchiseHallOfFameRepository.GetAll(query.Franchise.Id), query.Sport)
            {
                Franchise = query.Franchise
            };
        }
    }
}
