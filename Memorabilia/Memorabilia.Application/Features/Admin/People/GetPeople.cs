namespace Memorabilia.Application.Features.Admin.People;

public record GetPeople(int? SportId = null, 
                        int? SportLeagueLevelId = null) 
    : IQuery<Entity.Person[]>
{
    public class Handler(IPersonRepository personRepository) 
        : QueryHandler<GetPeople, Entity.Person[]>
    {
        protected override async Task<Entity.Person[]> Handle(GetPeople query)
            => (await personRepository.GetAll(query.SportId, query.SportLeagueLevelId))
                    .ToArray();
    }
}
