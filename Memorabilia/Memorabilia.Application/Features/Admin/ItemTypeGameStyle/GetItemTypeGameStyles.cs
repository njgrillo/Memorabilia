namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle
{
    public class GetItemTypeGameStyles : ViewModel
    {
        public class Handler : QueryHandler<Query, ItemTypeGameStylesViewModel>
        {
            private readonly IItemTypeGameStyleTypeRepository _itemTypeGameStyleRepository;

            public Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository)
            {
                _itemTypeGameStyleRepository = itemTypeGameStyleRepository;
            }

            protected override async Task<ItemTypeGameStylesViewModel> Handle(Query query)
            {
                return new ItemTypeGameStylesViewModel(await _itemTypeGameStyleRepository.GetAll(query.ItemTypeId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ItemTypeGameStylesViewModel>
        {
            public Query(int? itemTypeId = null)
            {
                ItemTypeId = itemTypeId;
            }

            public int? ItemTypeId { get; }
        }
    }
}
