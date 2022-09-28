namespace Memorabilia.Application.Features.Admin.People
{
    public class GetPersonTeams
    {
        public class Handler : QueryHandler<Query, PersonTeamsViewModel>
        {
            private readonly IPersonRepository _personRepository;

            public Handler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            protected override async Task<PersonTeamsViewModel> Handle(Query query)
            {
                return new PersonTeamsViewModel(await _personRepository.Get(query.PersonId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<PersonTeamsViewModel>
        {
            public Query(int personId)
            {
                PersonId = personId;
            }

            public int PersonId { get; }
        }
    }
}
