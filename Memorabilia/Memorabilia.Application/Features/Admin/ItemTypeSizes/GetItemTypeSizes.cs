namespace Memorabilia.Application.Features.Admin.ItemTypeSizes
{
    public class GetItemTypeSizes
    {
        public class Handler : QueryHandler<Query, ItemTypeSizesViewModel>
        {
            private readonly IItemTypeSizeRepository _itemTypeSizeRepository;

            public Handler(IItemTypeSizeRepository itemTypeSizeRepository)
            {
                _itemTypeSizeRepository = itemTypeSizeRepository;
            }

            protected override async Task<ItemTypeSizesViewModel> Handle(Query query)
            {
                var itemTypeSizes = (await _itemTypeSizeRepository.GetAll(query.ItemTypeId)
                                                                  .ConfigureAwait(false))
                                                                  .OrderBy(itemTypeSize => Domain.Constants.ItemType.Find(itemTypeSize.ItemTypeId).Name)
                                                                  .ThenBy(itemTypeSize => Domain.Constants.Size.Find(itemTypeSize.SizeId).Name);

                return new ItemTypeSizesViewModel(itemTypeSizes);
            }
        }

        public class Query : IQuery<ItemTypeSizesViewModel>
        {
            public Query(int? itemTypeId = null)
            {
                ItemTypeId = itemTypeId;
            }

            public int? ItemTypeId { get; }
        }
    }
}
