using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSize
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

                var viewModel = new ItemTypeSizesViewModel(itemTypeSizes);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeSizesViewModel>
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
