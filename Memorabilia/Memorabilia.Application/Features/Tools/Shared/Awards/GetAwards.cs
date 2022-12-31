using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.Awards;

public record GetAwards(AwardType AwardType, Sport Sport) : IQuery<AwardsViewModel>
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
            return new AwardsViewModel(await _personAwardRepository.GetAll(query.AwardType.Id), query.Sport)
            {
                AwardType = query.AwardType
            };
        }
    }
}
