namespace Memorabilia.Application.Features.Admin.ItemTypeBrand
{
    public class GetItemTypeBrand
    {
        public class Handler : QueryHandler<Query, ItemTypeBrandViewModel>
        {
            private readonly IItemTypeBrandRepository _itemTypeBrandRepository;

            public Handler(IItemTypeBrandRepository itemTypeBrandRepository)
            {
                _itemTypeBrandRepository = itemTypeBrandRepository;
            }

            protected override async Task<ItemTypeBrandViewModel> Handle(Query query)
            {
                return new ItemTypeBrandViewModel(await _itemTypeBrandRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ItemTypeBrandViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
