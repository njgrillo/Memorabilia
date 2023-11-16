namespace Memorabilia.Application.Features.Admin.People;

public record GetPersonByName(string DisplayName = null, 
                              string ProfileName = null,
                              string LegalName = null)
    : IQuery<Entity.Person>
{
    public class Handler(IPersonRepository personRepository) 
        : QueryHandler<GetPersonByName, Entity.Person>
    {
        protected override async Task<Entity.Person> Handle(GetPersonByName query)
            => await personRepository.Get(query.DisplayName,
                                           query.ProfileName,
                                           query.LegalName);
    }
}
