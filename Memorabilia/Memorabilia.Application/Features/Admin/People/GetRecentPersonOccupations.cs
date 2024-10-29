namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetRecentPersonOccupations() : IQuery<Entity.Person[]>
{
    public class Handler(IPersonRepository personRepository) 
        : QueryHandler<GetRecentPersonOccupations, Entity.Person[]>
    {
        protected override async Task<Entity.Person[]> Handle(GetRecentPersonOccupations query)
            => (await personRepository.GetMostRecent())
                    .ToArray();
    }
}
