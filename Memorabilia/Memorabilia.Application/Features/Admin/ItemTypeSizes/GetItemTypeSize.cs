namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public record GetItemTypeSize(int Id) : IQuery<ItemTypeSizeViewModel>
{
    public class Handler : QueryHandler<GetItemTypeSize, ItemTypeSizeViewModel>
    {
        private readonly IItemTypeSizeRepository _itemTypeSizeRepository;

        public Handler(IItemTypeSizeRepository itemTypeSizeRepository)
        {
            _itemTypeSizeRepository = itemTypeSizeRepository;
        }

        protected override async Task<ItemTypeSizeViewModel> Handle(GetItemTypeSize query)
        {
            return new ItemTypeSizeViewModel(await _itemTypeSizeRepository.Get(query.Id));
        }
    }
}
