namespace Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;

public record GetFranchiseHallOfFames(Constant.Franchise Franchise, 
                                      Constant.Sport Sport) 
    : IQuery<Entity.FranchiseHallOfFame[]>
{
    public class Handler : QueryHandler<GetFranchiseHallOfFames, Entity.FranchiseHallOfFame[]>
    {
        private readonly IFranchiseHallOfFameRepository _franchiseHallOfFameRepository;

        public Handler(IFranchiseHallOfFameRepository franchiseHallOfFameRepository)
        {
            _franchiseHallOfFameRepository = franchiseHallOfFameRepository;
        }

        protected override async Task<Entity.FranchiseHallOfFame[]> Handle(GetFranchiseHallOfFames query)
            => (await _franchiseHallOfFameRepository.GetAll(query.Franchise.Id))
                    .ToArray();
    }
}
