using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
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
                return new ItemTypeBrandsViewModel(await _itemTypeBrandRepository.GetAll(query.ItemTypeId).ConfigureAwait(false));
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
}
