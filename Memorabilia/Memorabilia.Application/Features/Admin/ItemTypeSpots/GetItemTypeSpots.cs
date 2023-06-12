namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public record GetItemTypeSpots(int? ItemTypeId = null) : IQuery<Entity.ItemTypeSpot[]>
{
    public class Handler : QueryHandler<GetItemTypeSpots, Entity.ItemTypeSpot[]>
    {
        private readonly IItemTypeSpotRepository _itemTypeSpotRepository;

        public Handler(IItemTypeSpotRepository itemTypeSpotRepository)
        {
            _itemTypeSpotRepository = itemTypeSpotRepository;
        }

        protected override async Task<Entity.ItemTypeSpot[]> Handle(GetItemTypeSpots query)
            => (await _itemTypeSpotRepository.GetAll(query.ItemTypeId))
                    .ToArray();
    }
}
