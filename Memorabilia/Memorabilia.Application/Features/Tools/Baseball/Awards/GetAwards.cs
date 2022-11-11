namespace Memorabilia.Application.Features.Tools.Baseball.Awards;

public record GetAwards(Domain.Constants.AwardType AwardType) : IQuery<AwardsViewModel>
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
            return new AwardsViewModel(await _personAwardRepository.GetAll(query.AwardType.Id))
            {
                AwardType = query.AwardType
            };
        }
    }
}
