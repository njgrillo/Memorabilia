namespace Memorabilia.Application.Features.Tools.Shared.HallOfFamers;

public record GetHallOfFames(Constant.SportLeagueLevel SportLeagueLevel, 
                             int? InductionYear = null) 
    : IQuery<Entity.HallOfFame[]>
{
    public class Handler : QueryHandler<GetHallOfFames, Entity.HallOfFame[]>
    {
        private readonly IHallOfFameRepository _hallOfFameRepository;

        public Handler(IHallOfFameRepository hallOfFameRepository)
        {
            _hallOfFameRepository = hallOfFameRepository;
        }

        protected override async Task<Entity.HallOfFame[]> Handle(GetHallOfFames query)
            => (await _hallOfFameRepository.GetAll(query.SportLeagueLevel.Id, query.InductionYear))
                    .ToArray();
    }
}
