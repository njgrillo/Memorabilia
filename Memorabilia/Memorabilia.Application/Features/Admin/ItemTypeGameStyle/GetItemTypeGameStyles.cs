namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

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
            var itemTypeGameStyles = (await _itemTypeGameStyleRepository.GetAll(query.ItemTypeId))
                                            .OrderBy(itemTypeGameStyleType => itemTypeGameStyleType.ItemTypeName)
                                            .ThenBy(itemTypeGameStyleType => itemTypeGameStyleType.GameStyleTypeName);

            return new ItemTypeGameStylesViewModel(itemTypeGameStyles);
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
