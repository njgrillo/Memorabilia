namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public record GetItemTypeSpot(int Id) : IQuery<Entity.ItemTypeSpot>
{
    public class Handler : QueryHandler<GetItemTypeSpot, Entity.ItemTypeSpot>
    {
        private readonly IItemTypeSpotRepository _itemTypeSpotRepository;

        public Handler(IItemTypeSpotRepository itemTypeSpotRepository)
        {
            _itemTypeSpotRepository = itemTypeSpotRepository;
        }

        protected override async Task<Entity.ItemTypeSpot> Handle(GetItemTypeSpot query)
            => await _itemTypeSpotRepository.Get(query.Id);
    }
}
