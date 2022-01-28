using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpot
{
    public class GetItemTypeSpot
    {
        public class Handler : QueryHandler<Query, ItemTypeSpotViewModel>
        {
            private readonly IItemTypeSpotRepository _itemTypeSpotRepository;

            public Handler(IItemTypeSpotRepository itemTypeSpotRepository)
            {
                _itemTypeSpotRepository = itemTypeSpotRepository;
            }

            protected override async Task<ItemTypeSpotViewModel> Handle(Query query)
            {
                var itemTypeSpot = await _itemTypeSpotRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new ItemTypeSpotViewModel(itemTypeSpot);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeSpotViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
