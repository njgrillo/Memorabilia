namespace Memorabilia.Application.Features.Tools.Baseball.Awards;

public record GetAwards(int AwardTypeId) : IQuery<AwardsViewModel>
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
            return new AwardsViewModel(await _personAwardRepository.GetAll(query.AwardTypeId))
            {
                AwardTypeId = query.AwardTypeId
            };
        }
    }
}
