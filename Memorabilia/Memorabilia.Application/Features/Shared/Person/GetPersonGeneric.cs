namespace Memorabilia.Application.Features.Shared.Person;

public record GetPersonGeneric(int Id) : IQuery<Entity.Person>
{
    public class Handler : QueryHandler<GetPersonGeneric, Entity.Person>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Entity.Person> Handle(GetPersonGeneric query)
        {
            return await _personRepository.Get(query.Id);
        }
    }
}
