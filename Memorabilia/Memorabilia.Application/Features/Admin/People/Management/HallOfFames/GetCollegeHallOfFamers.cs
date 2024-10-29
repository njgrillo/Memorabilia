namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetCollegeHallOfFamers(int CollegeId)
    : IQuery<CollegeHallOfFamesViewModel>
{
    public class Handler(ICollegeHallOfFameRepository hallOfFamerRepository)
        : QueryHandler<GetCollegeHallOfFamers, CollegeHallOfFamesViewModel>
    {
        protected override async Task<CollegeHallOfFamesViewModel> Handle(GetCollegeHallOfFamers query)
        {
            Entity.CollegeHallOfFame[] HallOfFamers
                = (await hallOfFamerRepository.GetAll(query.CollegeId)).ToArray();

            return new CollegeHallOfFamesViewModel(query.CollegeId, HallOfFamers);
        }
    }
}
