namespace Memorabilia.Application.Features.Admin.ItemTypeSpots
{
    public class GetItemTypeSpots
    {
        public class Handler : QueryHandler<Query, ItemTypeSpotsViewModel>
        {
            private readonly IItemTypeSpotRepository _itemTypeSpotRepository;

            public Handler(IItemTypeSpotRepository itemTypeSpotRepository)
            {
                _itemTypeSpotRepository = itemTypeSpotRepository;
            }

            protected override async Task<ItemTypeSpotsViewModel> Handle(Query query)
            {
                return new ItemTypeSpotsViewModel(await _itemTypeSpotRepository.GetAll(query.ItemTypeId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ItemTypeSpotsViewModel>
        {
            public Query(int? itemTypeId = null)
            {
                ItemTypeId = itemTypeId;
            }

            public int? ItemTypeId { get; }
        }
    }
}
