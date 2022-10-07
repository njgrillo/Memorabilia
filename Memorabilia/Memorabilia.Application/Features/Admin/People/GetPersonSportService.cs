namespace Memorabilia.Application.Features.Admin.People;

public class GetPersonSportService
{
    public class Handler : QueryHandler<Query, PersonSportServiceViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonSportServiceViewModel> Handle(Query query)
        {
            return new PersonSportServiceViewModel(await _personRepository.Get(query.PersonId));
        }
    }

    public class Query : IQuery<PersonSportServiceViewModel>
    {
        public Query(int personId)
        {
            PersonId = personId;
        }

        public int PersonId { get; }
    }
}
