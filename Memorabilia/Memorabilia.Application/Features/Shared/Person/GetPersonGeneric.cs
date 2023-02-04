namespace Memorabilia.Application.Features.Shared.Person;

public record GetPersonGeneric(int Id) : IQuery<Domain.Entities.Person>
{
    public class Handler : QueryHandler<GetPersonGeneric, Domain.Entities.Person>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Domain.Entities.Person> Handle(GetPersonGeneric query)
        {
            return await _personRepository.Get(query.Id);
        }
    }
}
