using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSport
{
    public class GetItemTypeSports
    {
        public class Handler : QueryHandler<Query, ItemTypeSportsViewModel>
        {
            private readonly IItemTypeSportRepository _itemTypeSportRepository;

            public Handler(IItemTypeSportRepository itemTypeSportRepository)
            {
                _itemTypeSportRepository = itemTypeSportRepository;
            }

            protected override async Task<ItemTypeSportsViewModel> Handle(Query query)
            {
                var itemTypeSports = await _itemTypeSportRepository.GetAll(query.ItemTypeId).ConfigureAwait(false);

                var viewModel = new ItemTypeSportsViewModel(itemTypeSports);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeSportsViewModel>
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
