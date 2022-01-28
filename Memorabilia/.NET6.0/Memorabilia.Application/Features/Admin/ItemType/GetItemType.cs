using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.ItemType
{
    public class GetItemType
    {
        public class Handler : QueryHandler<DomainQuery, DomainViewModel>
        {
            private readonly IItemTypeRepository _itemTypeRepository;

            public Handler(IItemTypeRepository itemTypeRepository)
            {
                _itemTypeRepository = itemTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(DomainQuery query)
            {
                var itemType = await _itemTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(itemType);

                return viewModel;
            }
        }
    }
}
