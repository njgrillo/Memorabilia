namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public record GetItemTypeBrands(int? ItemTypeId = null) : IQuery<ItemTypeBrandsViewModel>
{
    public class Handler : QueryHandler<GetItemTypeBrands, ItemTypeBrandsViewModel>
    {
        private readonly IItemTypeBrandRepository _itemTypeBrandRepository;

        public Handler(IItemTypeBrandRepository itemTypeBrandRepository)
        {
            _itemTypeBrandRepository = itemTypeBrandRepository;
        }

        protected override async Task<ItemTypeBrandsViewModel> Handle(GetItemTypeBrands query)
        {
            return new ItemTypeBrandsViewModel(await _itemTypeBrandRepository.GetAll(query.ItemTypeId));
        }
    }
}
