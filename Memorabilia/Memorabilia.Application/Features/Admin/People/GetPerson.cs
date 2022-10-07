namespace Memorabilia.Application.Features.Admin.People;

public class GetPerson
{
    public class Handler : QueryHandler<Query, PersonViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonViewModel> Handle(Query query)
        {
            return new PersonViewModel(await _personRepository.Get(query.Id));
        }
    }

    public class Query : IQuery<PersonViewModel>
    {
        public Query(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
