using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSports
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
                return new ItemTypeSportsViewModel(await _itemTypeSportRepository.GetAll(query.ItemTypeId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ItemTypeSportsViewModel>
        {
            public Query(int? itemTypeId = null)
            {
                ItemTypeId = itemTypeId;
            }

            public int? ItemTypeId { get; }
        }
    }
}
