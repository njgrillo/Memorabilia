namespace Memorabilia.Application.Features.Tools.Shared.Awards;

public record GetAwards(Domain.Constants.AwardType AwardType, Domain.Constants.SportLeagueLevel SportLeagueLevel) : IQuery<AwardsViewModel>
{
    public class Handler : QueryHandler<GetAwards, AwardsViewModel>
    {
        private readonly IPersonAwardRepository _personAwardRepository;

        public Handler(IPersonAwardRepository personAwardRepository)
        {
            _personAwardRepository = personAwardRepository;
        }

        protected override async Task<AwardsViewModel> Handle(GetAwards query)
        {
            return new AwardsViewModel(await _personAwardRepository.GetAll(query.AwardType.Id), query.SportLeagueLevel)
            {
                AwardType = query.AwardType
            };
        }
    }
}
