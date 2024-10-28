namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames.Sports;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetSportHallOfFamers(int SportLeagueLevelId)
    : IQuery<SportHallOfFameViewModel>
{
    public class Handler(IHallOfFameRepository HallOfFamerRepository)
        : QueryHandler<GetSportHallOfFamers, SportHallOfFameViewModel>
    {
        protected override async Task<SportHallOfFameViewModel> Handle(GetSportHallOfFamers query)
        {
            Entity.HallOfFame[] HallOfFamers
                = (await HallOfFamerRepository.GetAll(query.SportLeagueLevelId)).ToArray();

            return new SportHallOfFameViewModel(query.SportLeagueLevelId, HallOfFamers);
        }
    }
}
