namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public record GetItemTypeSport(int Id) : IQuery<ItemTypeSportViewModel>
{
    public class Handler : QueryHandler<GetItemTypeSport, ItemTypeSportViewModel>
    {
        private readonly IItemTypeSportRepository _itemTypeSportRepository;

        public Handler(IItemTypeSportRepository itemTypeSportRepository)
        {
            _itemTypeSportRepository = itemTypeSportRepository;
        }

        protected override async Task<ItemTypeSportViewModel> Handle(GetItemTypeSport query)
        {
            return new ItemTypeSportViewModel(await _itemTypeSportRepository.Get(query.Id));
        }
    }
}
