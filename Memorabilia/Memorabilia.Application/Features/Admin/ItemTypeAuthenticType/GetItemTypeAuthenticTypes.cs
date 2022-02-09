using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeAuthenticType
{
    public class GetItemTypeAuthenticTypes : ViewModel
    {
        public class Handler : QueryHandler<Query, ItemTypeAuthenticTypesViewModel>
        {
            private readonly IItemTypeAuthenticTypeRepository _itemTypeAuthenticTypeRepository;

            public Handler(IItemTypeAuthenticTypeRepository itemTypeAuthenticTypeRepository)
            {
                _itemTypeAuthenticTypeRepository = itemTypeAuthenticTypeRepository;
            }

            protected override async Task<ItemTypeAuthenticTypesViewModel> Handle(Query query)
            {
                var itemTypeAuthenticTypes = await _itemTypeAuthenticTypeRepository.GetAll(query.ItemTypeId).ConfigureAwait(false);

                var viewModel = new ItemTypeAuthenticTypesViewModel(itemTypeAuthenticTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeAuthenticTypesViewModel>
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
