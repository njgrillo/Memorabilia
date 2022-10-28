namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public record GetItemTypeLevels(int? ItemTypeId = null) : IQuery<ItemTypeLevelsViewModel>
{
    public class Handler : QueryHandler<GetItemTypeLevels, ItemTypeLevelsViewModel>
    {
        private readonly IItemTypeLevelRepository _itemTypeLevelRepository;

        public Handler(IItemTypeLevelRepository itemTypeLevelRepository)
        {
            _itemTypeLevelRepository = itemTypeLevelRepository;
        }

        protected override async Task<ItemTypeLevelsViewModel> Handle(GetItemTypeLevels query)
        {
            return new ItemTypeLevelsViewModel(await _itemTypeLevelRepository.GetAll(query.ItemTypeId));
        }
    }
}
