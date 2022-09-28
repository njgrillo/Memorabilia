namespace Memorabilia.Application.Features.Admin.ChampionTypes
{
    public class GetChampionTypes
    {
        public class Handler : QueryHandler<Query, ChampionTypesViewModel>
        {
            private readonly IChampionTypeRepository _championTypeRepository;

            public Handler(IChampionTypeRepository championTypeRepository)
            {
                _championTypeRepository = championTypeRepository;
            }

            protected override async Task<ChampionTypesViewModel> Handle(Query query)
            {
                return new ChampionTypesViewModel(await _championTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ChampionTypesViewModel> { }
    }
}
