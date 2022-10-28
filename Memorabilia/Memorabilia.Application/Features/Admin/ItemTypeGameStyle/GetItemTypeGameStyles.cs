namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public record GetItemTypeGameStyles(int? ItemTypeId = null) : IQuery<ItemTypeGameStylesViewModel>
{
    public class Handler : QueryHandler<GetItemTypeGameStyles, ItemTypeGameStylesViewModel>
    {
        private readonly IItemTypeGameStyleTypeRepository _itemTypeGameStyleRepository;

        public Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository)
        {
            _itemTypeGameStyleRepository = itemTypeGameStyleRepository;
        }

        protected override async Task<ItemTypeGameStylesViewModel> Handle(GetItemTypeGameStyles query)
        {
            return new ItemTypeGameStylesViewModel(await _itemTypeGameStyleRepository.GetAll(query.ItemTypeId));
        }
    }
}
