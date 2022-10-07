namespace Memorabilia.Application.Features.Admin.People;

public class GetPersonImage
{
    public class Handler : QueryHandler<Query, PersonImageViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonImageViewModel> Handle(Query query)
        {
            var person = await _personRepository.Get(query.PersonId);

            return new PersonImageViewModel(person);
        }
    }

    public class Query : IQuery<PersonImageViewModel>
    {
        public Query(int personId)
        {
            PersonId = personId;
        }

        public int PersonId { get; }
    }
}
