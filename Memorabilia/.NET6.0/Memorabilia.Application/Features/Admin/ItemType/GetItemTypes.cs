using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.ItemType
{
    public class GetItemTypes
    {
        public class Handler : QueryHandler<Query, ItemTypesViewModel>
        {
            private readonly IItemTypeRepository _itemTypeRepository;

            public Handler(IItemTypeRepository itemTypeRepository)
            {
                _itemTypeRepository = itemTypeRepository;
            }

            protected override async Task<ItemTypesViewModel> Handle(Query query)
            {
                var itemTypes = await _itemTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new ItemTypesViewModel(itemTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypesViewModel>
        {
        }
    }
}
