namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

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
            var itemTypeSports = (await _itemTypeSportRepository.GetAll(query.ItemTypeId))
                                            .OrderBy(itemTypeSport => itemTypeSport.ItemTypeName)
                                            .ThenBy(itemTypeSport => itemTypeSport.SportName);

            return new ItemTypeSportsViewModel(itemTypeSports);
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
