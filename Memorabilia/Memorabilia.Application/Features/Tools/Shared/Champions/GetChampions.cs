namespace Memorabilia.Application.Features.Tools.Shared.Champions;

public record GetChampions(int ChampionTypeId, Constant.Sport Sport) : IQuery<Entity.Champion[]>
{
    public class Handler(IChampionRepository championRepository) 
        : QueryHandler<GetChampions, Entity.Champion[]>
    {
        protected override async Task<Entity.Champion[]> Handle(GetChampions query)
            => (await championRepository.GetAll(query.ChampionTypeId))
                    .ToArray();
    }
}
