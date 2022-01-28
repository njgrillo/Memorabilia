using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemType
{
    public class GetItemType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IItemTypeRepository _itemTypeRepository;

            public Handler(IItemTypeRepository itemTypeRepository)
            {
                _itemTypeRepository = itemTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var itemType = await _itemTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(itemType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id)
            {
            }
        }
    }
}
