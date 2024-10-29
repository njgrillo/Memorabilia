namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetInternationalHallOfFamers(int InternationalHallOfFameTypeId)
    : IQuery<InternationalHallOfFamesViewModel>
{
    public class Handler(IInternationalHallOfFameRepository hallOfFamerRepository)
        : QueryHandler<GetInternationalHallOfFamers, InternationalHallOfFamesViewModel>
    {
        protected override async Task<InternationalHallOfFamesViewModel> Handle(GetInternationalHallOfFamers query)
        {
            Entity.InternationalHallOfFame[] HallOfFamers
                = (await hallOfFamerRepository.GetAll(query.InternationalHallOfFameTypeId)).ToArray();

            return new InternationalHallOfFamesViewModel(query.InternationalHallOfFameTypeId, HallOfFamers);
        }
    }
}
