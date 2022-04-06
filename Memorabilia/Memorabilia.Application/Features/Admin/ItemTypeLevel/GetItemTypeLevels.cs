using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
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
                return new ItemTypeLevelsViewModel(await _itemTypeLevelRepository.GetAll(query.ItemTypeId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ItemTypeLevelsViewModel>
        {
            public Query(int? itemTypeId = null)
            {
                ItemTypeId = itemTypeId;
            }

            public int? ItemTypeId { get; }
        }
    }
}
