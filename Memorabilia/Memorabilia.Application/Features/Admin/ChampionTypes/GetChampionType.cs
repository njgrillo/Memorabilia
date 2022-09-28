namespace Memorabilia.Application.Features.Admin.ChampionTypes
{
    public class GetChampionType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IChampionTypeRepository _championTypeRepository;

            public Handler(IChampionTypeRepository championTypeRepository)
            {
                _championTypeRepository = championTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _championTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
