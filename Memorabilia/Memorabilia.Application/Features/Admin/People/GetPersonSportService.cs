namespace Memorabilia.Application.Features.Admin.People;

public record GetPersonSportService(int PersonId) : IQuery<PersonSportServiceViewModel>
{
    public class Handler : QueryHandler<GetPersonSportService, PersonSportServiceViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonSportServiceViewModel> Handle(GetPersonSportService query)
        {
            return new PersonSportServiceViewModel(await _personRepository.Get(query.PersonId));
        }
    }
}
