namespace Memorabilia.Application.Features.Tools.Baseball.HallOfFames;

public record GetHallOfFames(int? SportLeagueLevelId = null, int? InductionYear = null) : IQuery<HallOfFamesViewModel>
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
            return new HallOfFamesViewModel(await _hallOfFameRepository.GetAll(query.SportLeagueLevelId, query.InductionYear))
            {
                InductionYear = query.InductionYear ?? 0
            };
        }
    }
}
