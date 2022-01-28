using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeBrand
{
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
                var itemTypeBrands = await _itemTypeBrandRepository.GetAll(query.ItemTypeId).ConfigureAwait(false);

                var viewModel = new ItemTypeBrandsViewModel(itemTypeBrands);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeBrandsViewModel>
        {
            public Query() { }

            public Query(int itemTypeId)
            {
                ItemTypeId = itemTypeId;
            }

            public int? ItemTypeId { get; }
        }
    }
}
