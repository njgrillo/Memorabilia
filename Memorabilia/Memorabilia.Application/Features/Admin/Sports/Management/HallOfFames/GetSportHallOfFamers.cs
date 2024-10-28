namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetSportHallOfFamers(int SportLeagueLevelId)
    : IQuery<SportHallOfFamesViewModel>
{
    public class Handler(IHallOfFameRepository hallOfFamerRepository)
        : QueryHandler<GetSportHallOfFamers, SportHallOfFamesViewModel>
    {
        protected override async Task<SportHallOfFamesViewModel> Handle(GetSportHallOfFamers query)
        {
            Entity.HallOfFame[] HallOfFamers
                = (await hallOfFamerRepository.GetAll(query.SportLeagueLevelId)).ToArray();

            return new SportHallOfFamesViewModel(query.SportLeagueLevelId, HallOfFamers);
        }
    }
}
