namespace Memorabilia.Application.Features.Admin.ItemTypeSports
{
    public class GetItemTypeSport
    {
        public class Handler : QueryHandler<Query, ItemTypeSportViewModel>
        {
            private readonly IItemTypeSportRepository _itemTypeSportRepository;

            public Handler(IItemTypeSportRepository itemTypeSportRepository)
            {
                _itemTypeSportRepository = itemTypeSportRepository;
            }

            protected override async Task<ItemTypeSportViewModel> Handle(Query query)
            {
                return new ItemTypeSportViewModel(await _itemTypeSportRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ItemTypeSportViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
