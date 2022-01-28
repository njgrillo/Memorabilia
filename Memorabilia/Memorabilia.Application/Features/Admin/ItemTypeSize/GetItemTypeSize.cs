using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSize
{
    public class GetItemTypeSize
    {
        public class Handler : QueryHandler<Query, ItemTypeSizeViewModel>
        {
            private readonly IItemTypeSizeRepository _itemTypeSizeRepository;

            public Handler(IItemTypeSizeRepository itemTypeSizeRepository)
            {
                _itemTypeSizeRepository = itemTypeSizeRepository;
            }

            protected override async Task<ItemTypeSizeViewModel> Handle(Query query)
            {
                var itemTypeSize = await _itemTypeSizeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new ItemTypeSizeViewModel(itemTypeSize);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeSizeViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
