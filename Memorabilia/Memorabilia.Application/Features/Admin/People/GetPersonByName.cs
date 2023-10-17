namespace Memorabilia.Application.Features.Admin.People;

public record GetPersonByName(string DisplayName = null, 
                              string ProfileName = null,
                              string LegalName = null)
    : IQuery<Entity.Person>
{
    public class Handler : QueryHandler<GetPersonByName, Entity.Person>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Entity.Person> Handle(GetPersonByName query)
            => await _personRepository.Get(query.DisplayName,
                                           query.ProfileName,
                                           query.LegalName);
    }
}
