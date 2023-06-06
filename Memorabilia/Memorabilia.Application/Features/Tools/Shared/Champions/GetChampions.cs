namespace Memorabilia.Application.Features.Tools.Shared.Champions;

public record GetChampions(int ChampionTypeId, Constant.Sport Sport) : IQuery<ChampionsModel>
{
    public class Handler : QueryHandler<GetChampions, ChampionsModel>
    {
        private readonly IChampionRepository _championRepository;

        public Handler(IChampionRepository championRepository)
        {
            _championRepository = championRepository;
        }

        protected override async Task<ChampionsModel> Handle(GetChampions query)
        {
            return new ChampionsModel(await _championRepository.GetAll(query.ChampionTypeId), query.Sport);
        }
    }
}
