namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public record GetItemTypeGameStyle(int Id) : IQuery<ItemTypeGameStyleViewModel>
{
    public class Handler : QueryHandler<GetItemTypeGameStyle, ItemTypeGameStyleViewModel>
    {
        private readonly IItemTypeGameStyleTypeRepository _itemTypeGameStyleRepository;

        public Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository)
        {
            _itemTypeGameStyleRepository = itemTypeGameStyleRepository;
        }

        protected override async Task<ItemTypeGameStyleViewModel> Handle(GetItemTypeGameStyle query)
        {
            return new ItemTypeGameStyleViewModel(await _itemTypeGameStyleRepository.Get(query.Id));
        }
    }
}
