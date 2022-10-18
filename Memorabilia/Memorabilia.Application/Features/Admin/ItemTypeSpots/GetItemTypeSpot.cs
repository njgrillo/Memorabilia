namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public record GetItemTypeSpot(int Id) : IQuery<ItemTypeSpotViewModel>
{
    public class Handler : QueryHandler<GetItemTypeSpot, ItemTypeSpotViewModel>
    {
        private readonly IItemTypeSpotRepository _itemTypeSpotRepository;

        public Handler(IItemTypeSpotRepository itemTypeSpotRepository)
        {
            _itemTypeSpotRepository = itemTypeSpotRepository;
        }

        protected override async Task<ItemTypeSpotViewModel> Handle(GetItemTypeSpot query)
        {
            return new ItemTypeSpotViewModel(await _itemTypeSpotRepository.Get(query.Id));
        }
    }
}
