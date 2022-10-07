namespace Memorabilia.Application.Features.Admin.People;

public class GetPersonAccomplishments
{
    public class Handler : QueryHandler<Query, PersonAccoladeViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonAccoladeViewModel> Handle(Query query)
        {
            return new PersonAccoladeViewModel(await _personRepository.Get(query.PersonId));
        }
    }

    public class Query : IQuery<PersonAccoladeViewModel>
    {
        public Query(int personId)
        {
            PersonId = personId;
        }

        public int PersonId { get; }
    }
}
