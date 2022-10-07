namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public class GetItemTypeBrands
{
    public class Handler : QueryHandler<Query, ItemTypeBrandsViewModel>
    {
        private readonly IItemTypeBrandRepository _itemTypeBrandRepository;

        public Handler(IItemTypeBrandRepository itemTypeBrandRepository)
        {
            _itemTypeBrandRepository = itemTypeBrandRepository;
        }

        protected override async Task<ItemTypeBrandsViewModel> Handle(Query query)
        {
            var itemTypeBrands = (await _itemTypeBrandRepository.GetAll(query.ItemTypeId))
                                         .OrderBy(itemTypeBrand => itemTypeBrand.ItemTypeName)
                                         .ThenBy(itemTypeBrand => itemTypeBrand.BrandName);

            return new ItemTypeBrandsViewModel(itemTypeBrands);
        }
    }

    public class Query : IQuery<ItemTypeBrandsViewModel>
    {
        public Query(int? itemTypeId = null)
        {
            ItemTypeId = itemTypeId;
        }

        public int? ItemTypeId { get; }
    }
}
