namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle
{
    public class GetItemTypeGameStyle
    {
        public class Handler : QueryHandler<Query, ItemTypeGameStyleViewModel>
        {
            private readonly IItemTypeGameStyleTypeRepository _itemTypeGameStyleRepository;

            public Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository)
            {
                _itemTypeGameStyleRepository = itemTypeGameStyleRepository;
            }

            protected override async Task<ItemTypeGameStyleViewModel> Handle(Query query)
            {
                return new ItemTypeGameStyleViewModel(await _itemTypeGameStyleRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ItemTypeGameStyleViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
