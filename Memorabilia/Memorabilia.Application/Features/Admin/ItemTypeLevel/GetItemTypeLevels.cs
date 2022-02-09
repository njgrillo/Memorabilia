using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeLevel
{
    public class GetItemTypeLevels : ViewModel
    {
        public class Handler : QueryHandler<Query, ItemTypeLevelsViewModel>
        {
            private readonly IItemTypeLevelRepository _itemTypeLevelRepository;

            public Handler(IItemTypeLevelRepository itemTypeLevelRepository)
            {
                _itemTypeLevelRepository = itemTypeLevelRepository;
            }

            protected override async Task<ItemTypeLevelsViewModel> Handle(Query query)
            {
                var itemTypeLevels = await _itemTypeLevelRepository.GetAll(query.ItemTypeId).ConfigureAwait(false);

                var viewModel = new ItemTypeLevelsViewModel(itemTypeLevels);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeLevelsViewModel>
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
