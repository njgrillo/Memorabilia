namespace Memorabilia.Application.Features.Tools.Shared.LifeDates;

public record GetLifeDates(
    PageInfo PageInfo, 
    int? SportId = null, 
    string Filter = null,
    bool? IsToday = null,
    DateTime? BirthMonthDay = null,
    int? BirthMonth = null,
    int? BirthYear = null,
    DateTime? BirthDate = null,
    DateTime? DeathMonthDay = null,
    int? DeathMonth = null,
    int? DeathYear = null,
    DateTime? DeathDate = null
    )
    : IQuery<LifeDatesViewModel>
{
    public class Handler(IPersonRepository personRepository)
        : QueryHandler<GetLifeDates, LifeDatesViewModel>
    {
        protected override async Task<LifeDatesViewModel> Handle(GetLifeDates query)
        {
            PagedResult<Entity.Person> result
                = await personRepository.GetAll(
                    query.PageInfo, 
                    query.SportId, 
                    query.Filter,
                    query.IsToday,
                    query.BirthMonthDay,
                    query.BirthMonth,
                    query.BirthYear,
                    query.BirthDate,
                    query.DeathMonthDay,
                    query.DeathMonth,
                    query.DeathYear,
                    query.DeathDate
                    );

            return new LifeDatesViewModel(result.Data, Constant.Sport.Find(query.SportId ?? 0), result.PageInfo);
        }
    }
}
