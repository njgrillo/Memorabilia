namespace Memorabilia.Application.Features.Admin.People
{
    public class GetPersonHallOfFames
    {
        public class Handler : QueryHandler<Query, PersonHallOfFameViewModel>
        {
            private readonly IPersonRepository _personRepository;

            public Handler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            protected override async Task<PersonHallOfFameViewModel> Handle(Query query)
            {
                return new PersonHallOfFameViewModel(await _personRepository.Get(query.PersonId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<PersonHallOfFameViewModel>
        {
            public Query(int personId)
            {
                PersonId = personId;
            }

            public int PersonId { get; }
        }
    }
}
