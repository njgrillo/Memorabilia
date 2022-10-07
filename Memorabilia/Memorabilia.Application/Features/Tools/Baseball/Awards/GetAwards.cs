namespace Memorabilia.Application.Features.Tools.Baseball.Awards;

public class GetAwards
{
    public class Handler : QueryHandler<Query, AwardsViewModel>
    {
        private readonly IPersonAwardRepository _personAwardRepository;

        public Handler(IPersonAwardRepository personAwardRepository)
        {
            _personAwardRepository = personAwardRepository;
        }

        protected override async Task<AwardsViewModel> Handle(Query query)
        {
            var personAwards = (await _personAwardRepository.GetAll(query.AwardTypeId))
                                        .OrderByDescending(personAward => personAward.Year)
                                        .ThenBy(personAward => personAward.Person.DisplayName);

            return new AwardsViewModel(personAwards);
        }
    }

    public class Query : IQuery<AwardsViewModel>
    {
        public Query(int awardTypeId)
        {
            AwardTypeId = awardTypeId;
        }

        public int AwardTypeId { get; }
    }
}
