namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public record GetItemTypeLevel(int Id) : IQuery<ItemTypeLevelViewModel>
{
    public class Handler : QueryHandler<GetItemTypeLevel, ItemTypeLevelViewModel>
    {
        private readonly IItemTypeLevelRepository _itemTypeLevelRepository;

        public Handler(IItemTypeLevelRepository itemTypeLevelRepository)
        {
            _itemTypeLevelRepository = itemTypeLevelRepository;
        }

        protected override async Task<ItemTypeLevelViewModel> Handle(GetItemTypeLevel query)
        {
            return new ItemTypeLevelViewModel(await _itemTypeLevelRepository.Get(query.Id));
        }
    }
}
