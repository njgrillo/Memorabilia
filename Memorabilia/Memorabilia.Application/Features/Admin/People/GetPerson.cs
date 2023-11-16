namespace Memorabilia.Application.Features.Admin.People;

public record GetPerson(int Id) 
    : IQuery<Entity.Person>
{
    public class Handler(IPersonRepository personRepository) 
        : QueryHandler<GetPerson, Entity.Person>
    {
        protected override async Task<Entity.Person> Handle(GetPerson query)
            => await personRepository.Get(query.Id);
    }
}
