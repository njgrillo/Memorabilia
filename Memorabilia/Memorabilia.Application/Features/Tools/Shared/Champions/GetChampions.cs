namespace Memorabilia.Application.Features.Tools.Shared.Champions;

public record GetChampions(int ChampionTypeId, Constant.Sport Sport) : IQuery<Entity.Champion[]>
{
    public class Handler : QueryHandler<GetChampions, Entity.Champion[]>
    {
        private readonly IChampionRepository _championRepository;

        public Handler(IChampionRepository championRepository)
        {
            _championRepository = championRepository;
        }

        protected override async Task<Entity.Champion[]> Handle(GetChampions query)
            => (await _championRepository.GetAll(query.ChampionTypeId))
                    .ToArray();
    }
}
