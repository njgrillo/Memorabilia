using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeLevel
{
    public class GetItemTypeLevel
    {
        public class Handler : QueryHandler<Query, ItemTypeLevelViewModel>
        {
            private readonly IItemTypeLevelRepository _itemTypeLevelRepository;

            public Handler(IItemTypeLevelRepository itemTypeLevelRepository)
            {
                _itemTypeLevelRepository = itemTypeLevelRepository;
            }

            protected override async Task<ItemTypeLevelViewModel> Handle(Query query)
            {
                var itemTypeLevel = await _itemTypeLevelRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new ItemTypeLevelViewModel(itemTypeLevel);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeLevelViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
