namespace Memorabilia.Application.Features.Tools.Profile.Football;

public class GetFootballProfile
{
    public class Handler : QueryHandler<Query, FootballProfileViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<FootballProfileViewModel> Handle(Query query)
        {
            return new FootballProfileViewModel(await _personRepository.Get(query.PersonId));
        }
    }

    public class Query : IQuery<FootballProfileViewModel>
    {
        public Query(int personId)
        {
            PersonId = personId;
        }

        public int PersonId { get; }
    }
}
