namespace Memorabilia.Application.Features.Admin.People;

public record GetPeople(
    int? SportId = null, 
    int? SportLeagueLevelId = null,
    bool? IncludeUserAddedPersons = null,
    bool? FilterOutDeceased = null
    ) 
    : IQuery<Entity.Person[]>
{
    public class Handler(IPersonRepository personRepository, IApplicationStateService applicationStateService) 
        : QueryHandler<GetPeople, Entity.Person[]>
    {
        protected override async Task<Entity.Person[]> Handle(GetPeople query)
        {
            int? userId = !query.IncludeUserAddedPersons ?? false 
                ? null 
                : applicationStateService.CurrentUser.Id;

            return (await personRepository.GetAll(query.SportId, query.SportLeagueLevelId, userId, query.FilterOutDeceased))
                    .ToArray();
        }
            
    }
}
