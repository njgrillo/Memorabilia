namespace Memorabilia.Application.Features.Tools.Baseball.Champions;

public record GetChampions(int ChampionTypeId) : IQuery<ChampionsViewModel>
{
    public class Handler : QueryHandler<GetChampions, ChampionsViewModel>
    {
        private readonly IChampionRepository _championRepository;

        public Handler(IChampionRepository championRepository)
        {
            _championRepository = championRepository;
        }

        protected override async Task<ChampionsViewModel> Handle(GetChampions query)
        {
            return new ChampionsViewModel(await _championRepository.GetAll(query.ChampionTypeId));
        }
    }
}
