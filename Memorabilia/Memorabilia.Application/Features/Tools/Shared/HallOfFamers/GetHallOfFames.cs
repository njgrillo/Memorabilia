namespace Memorabilia.Application.Features.Tools.Shared.HallOfFamers;

public record GetHallOfFames(Constant.SportLeagueLevel SportLeagueLevel, 
                             int? InductionYear = null) 
    : IQuery<Entity.HallOfFame[]>
{
    public class Handler(IHallOfFameRepository hallOfFameRepository) 
        : QueryHandler<GetHallOfFames, Entity.HallOfFame[]>
    {
        protected override async Task<Entity.HallOfFame[]> Handle(GetHallOfFames query)
            => (await hallOfFameRepository.GetAll(query.SportLeagueLevel.Id, query.InductionYear))
                    .ToArray();
    }
}
