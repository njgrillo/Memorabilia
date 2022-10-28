namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public record GetItemTypeSpots(int? ItemTypeId = null) : IQuery<ItemTypeSpotsViewModel>
{
    public class Handler : QueryHandler<GetItemTypeSpots, ItemTypeSpotsViewModel>
    {
        private readonly IItemTypeSpotRepository _itemTypeSpotRepository;

        public Handler(IItemTypeSpotRepository itemTypeSpotRepository)
        {
            _itemTypeSpotRepository = itemTypeSpotRepository;
        }

        protected override async Task<ItemTypeSpotsViewModel> Handle(GetItemTypeSpots query)
        {
            return new ItemTypeSpotsViewModel(await _itemTypeSpotRepository.GetAll(query.ItemTypeId));
        }
    }
}
