using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpot
{
    public class GetItemTypeSpots
    {
        public class Handler : QueryHandler<Query, ItemTypeSpotsViewModel>
        {
            private readonly IItemTypeSpotRepository _itemTypeSpotRepository;

            public Handler(IItemTypeSpotRepository itemTypeSpotRepository)
            {
                _itemTypeSpotRepository = itemTypeSpotRepository;
            }

            protected override async Task<ItemTypeSpotsViewModel> Handle(Query query)
            {
                var itemTypeSpots = await _itemTypeSpotRepository.GetAll(query.ItemTypeId).ConfigureAwait(false);

                var viewModel = new ItemTypeSpotsViewModel(itemTypeSpots);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeSpotsViewModel>
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
