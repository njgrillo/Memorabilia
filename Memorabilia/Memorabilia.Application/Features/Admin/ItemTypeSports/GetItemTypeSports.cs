namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public record GetItemTypeSports(int? ItemTypeId = null) : IQuery<ItemTypeSportsViewModel>
{
    public class Handler : QueryHandler<GetItemTypeSports, ItemTypeSportsViewModel>
    {
        private readonly IItemTypeSportRepository _itemTypeSportRepository;

        public Handler(IItemTypeSportRepository itemTypeSportRepository)
        {
            _itemTypeSportRepository = itemTypeSportRepository;
        }

        protected override async Task<ItemTypeSportsViewModel> Handle(GetItemTypeSports query)
        {
            return new ItemTypeSportsViewModel(await _itemTypeSportRepository.GetAll(query.ItemTypeId));
        }
    }
}
