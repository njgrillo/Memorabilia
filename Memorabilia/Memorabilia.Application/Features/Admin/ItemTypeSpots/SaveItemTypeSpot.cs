namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public record SaveItemTypeSpot(ItemTypeSpotEditModel ItemTypeSpot) : ICommand
{
    public class Handler : CommandHandler<SaveItemTypeSpot>
    {
        private readonly IItemTypeSpotRepository _itemTypeSpotRepository;

        public Handler(IItemTypeSpotRepository itemTypeSpotRepository)
        {
            _itemTypeSpotRepository = itemTypeSpotRepository;
        }

        protected override async Task Handle(SaveItemTypeSpot request)
        {
            Entity.ItemTypeSpot itemTypeSpot;

            if (request.ItemTypeSpot.IsNew)
            {
                itemTypeSpot = new Entity.ItemTypeSpot(request.ItemTypeSpot.ItemType.Id, 
                                                       request.ItemTypeSpot.Spot.Id);

                await _itemTypeSpotRepository.Add(itemTypeSpot);

                return;
            }

            itemTypeSpot = await _itemTypeSpotRepository.Get(request.ItemTypeSpot.Id);

            if (request.ItemTypeSpot.IsDeleted)
            {
                await _itemTypeSpotRepository.Delete(itemTypeSpot);

                return;
            }

            itemTypeSpot.Set(request.ItemTypeSpot.Spot.Id);

            await _itemTypeSpotRepository.Update(itemTypeSpot);
        }
    }
}
