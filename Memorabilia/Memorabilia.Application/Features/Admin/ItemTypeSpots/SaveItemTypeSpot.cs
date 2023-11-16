namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveItemTypeSpot(ItemTypeSpotEditModel ItemTypeSpot) : ICommand
{
    public class Handler(IItemTypeSpotRepository itemTypeSpotRepository) 
        : CommandHandler<SaveItemTypeSpot>
    {
        protected override async Task Handle(SaveItemTypeSpot request)
        {
            Entity.ItemTypeSpot itemTypeSpot;

            if (request.ItemTypeSpot.IsNew)
            {
                itemTypeSpot = new Entity.ItemTypeSpot(request.ItemTypeSpot.ItemType.Id, 
                                                       request.ItemTypeSpot.Spot.Id);

                await itemTypeSpotRepository.Add(itemTypeSpot);

                return;
            }

            itemTypeSpot = await itemTypeSpotRepository.Get(request.ItemTypeSpot.Id);

            if (request.ItemTypeSpot.IsDeleted)
            {
                await itemTypeSpotRepository.Delete(itemTypeSpot);

                return;
            }

            itemTypeSpot.Set(request.ItemTypeSpot.Spot.Id);

            await itemTypeSpotRepository.Update(itemTypeSpot);
        }
    }
}
