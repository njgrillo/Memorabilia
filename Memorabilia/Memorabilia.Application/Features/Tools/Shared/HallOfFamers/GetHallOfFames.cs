using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.HallOfFamers;

public record GetHallOfFames(SportLeagueLevel SportLeagueLevel, int? InductionYear = null) 
    : IQuery<HallOfFamesViewModel>
{
    public class Handler : QueryHandler<GetHallOfFames, HallOfFamesViewModel>
    {
        private readonly IHallOfFameRepository _hallOfFameRepository;

        public Handler(IHallOfFameRepository hallOfFameRepository)
        {
            _hallOfFameRepository = hallOfFameRepository;
        }

        protected override async Task<HallOfFamesViewModel> Handle(GetHallOfFames query)
        {
            return new HallOfFamesViewModel(await _hallOfFameRepository.GetAll(query.SportLeagueLevel.Id, query.InductionYear), query.SportLeagueLevel.Sport)
            {
                InductionYear = query.InductionYear ?? 0
            };
        }
    }
}
