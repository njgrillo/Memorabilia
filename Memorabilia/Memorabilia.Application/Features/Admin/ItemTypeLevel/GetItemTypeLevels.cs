namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public class GetItemTypeLevels : ViewModel
{
    public class Handler : QueryHandler<Query, ItemTypeLevelsViewModel>
    {
        private readonly IItemTypeLevelRepository _itemTypeLevelRepository;

        public Handler(IItemTypeLevelRepository itemTypeLevelRepository)
        {
            _itemTypeLevelRepository = itemTypeLevelRepository;
        }

        protected override async Task<ItemTypeLevelsViewModel> Handle(Query query)
        {
            var itemTypeLevels = (await _itemTypeLevelRepository.GetAll(query.ItemTypeId))
                                                 .OrderBy(itemTypeLevel => itemTypeLevel.ItemTypeName)
                                                 .ThenBy(itemTypeLevel => itemTypeLevel.LevelTypeName);

            return new ItemTypeLevelsViewModel(itemTypeLevels);
        }
    }

    public class Query : IQuery<ItemTypeLevelsViewModel>
    {
        public Query(int? itemTypeId = null)
        {
            ItemTypeId = itemTypeId;
        }

        public int? ItemTypeId { get; }
    }
}
