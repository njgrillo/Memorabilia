namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public record GetItemTypeSpots(int? ItemTypeId = null) : IQuery<Entity.ItemTypeSpot[]>
{
    public class Handler(IItemTypeSpotRepository itemTypeSpotRepository) 
        : QueryHandler<GetItemTypeSpots, Entity.ItemTypeSpot[]>
    {
        protected override async Task<Entity.ItemTypeSpot[]> Handle(GetItemTypeSpots query)
            => await itemTypeSpotRepository.GetAll(query.ItemTypeId);
    }
}
