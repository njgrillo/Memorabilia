namespace Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;

public record GetFranchiseHallOfFames(Constant.Franchise Franchise, 
                                      Constant.Sport Sport) 
    : IQuery<Entity.FranchiseHallOfFame[]>
{
    public class Handler(IFranchiseHallOfFameRepository franchiseHallOfFameRepository) 
        : QueryHandler<GetFranchiseHallOfFames, Entity.FranchiseHallOfFame[]>
    {
        protected override async Task<Entity.FranchiseHallOfFame[]> Handle(GetFranchiseHallOfFames query)
            => (await franchiseHallOfFameRepository.GetAll(query.Franchise.Id))
                    .ToArray();
    }
}
