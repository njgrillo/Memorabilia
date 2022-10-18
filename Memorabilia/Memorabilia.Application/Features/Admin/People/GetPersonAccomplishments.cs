namespace Memorabilia.Application.Features.Admin.People;

public record GetPersonAccomplishments(int PersonId) : IQuery<PersonAccoladeViewModel>
{
    public class Handler : QueryHandler<GetPersonAccomplishments, PersonAccoladeViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonAccoladeViewModel> Handle(GetPersonAccomplishments query)
        {
            return new PersonAccoladeViewModel(await _personRepository.Get(query.PersonId));
        }
    }
}
