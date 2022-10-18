namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public record GetItemTypeSizes(int? ItemTypeId = null) : IQuery<ItemTypeSizesViewModel>
{
    public class Handler : QueryHandler<GetItemTypeSizes, ItemTypeSizesViewModel>
    {
        private readonly IItemTypeSizeRepository _itemTypeSizeRepository;

        public Handler(IItemTypeSizeRepository itemTypeSizeRepository)
        {
            _itemTypeSizeRepository = itemTypeSizeRepository;
        }

        protected override async Task<ItemTypeSizesViewModel> Handle(GetItemTypeSizes query)
        {
            var itemTypeSizes = (await _itemTypeSizeRepository.GetAll(query.ItemTypeId))
                                                              .OrderBy(itemTypeSize => itemTypeSize.ItemTypeName)
                                                              .ThenBy(itemTypeSize => itemTypeSize.SizeName);

            return new ItemTypeSizesViewModel(itemTypeSizes);
        }
    }
}
