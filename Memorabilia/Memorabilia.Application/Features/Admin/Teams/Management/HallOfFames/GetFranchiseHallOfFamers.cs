namespace Memorabilia.Application.Features.Admin.Teams.Management.HallOfFames;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetFranchiseHallOfFamers(int FranchiseId)
    : IQuery<FranchiseHallOfFamesViewModel>
{
    public class Handler(IFranchiseHallOfFameRepository hallOfFamerRepository)
        : QueryHandler<GetFranchiseHallOfFamers, FranchiseHallOfFamesViewModel>
    {
        protected override async Task<FranchiseHallOfFamesViewModel> Handle(GetFranchiseHallOfFamers query)
        {
            Entity.FranchiseHallOfFame[] HallOfFamers
                = (await hallOfFamerRepository.GetAll(query.FranchiseId)).ToArray();

            return new FranchiseHallOfFamesViewModel(query.FranchiseId, HallOfFamers);
        }
    }
}
