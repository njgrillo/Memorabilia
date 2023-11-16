namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public record GetItemTypeSpot(int Id) : IQuery<Entity.ItemTypeSpot>
{
    public class Handler(IItemTypeSpotRepository itemTypeSpotRepository) 
        : QueryHandler<GetItemTypeSpot, Entity.ItemTypeSpot>
    {
        protected override async Task<Entity.ItemTypeSpot> Handle(GetItemTypeSpot query)
            => await itemTypeSpotRepository.Get(query.Id);
    }
}
