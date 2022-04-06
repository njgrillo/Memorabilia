using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpots
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
                return new ItemTypeSpotViewModel(await _itemTypeSpotRepository.Get(query.Id).ConfigureAwait(false));
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
