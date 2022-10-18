using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public record SaveItemTypeSpot(SaveItemTypeSpotViewModel ViewModel) : ICommand
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
            ItemTypeSpot itemTypeSpot;

            if (request.ViewModel.IsNew)
            {
                itemTypeSpot = new ItemTypeSpot(request.ViewModel.ItemTypeId, request.ViewModel.SpotId);

                await _itemTypeSpotRepository.Add(itemTypeSpot);

                return;
            }

            itemTypeSpot = await _itemTypeSpotRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _itemTypeSpotRepository.Delete(itemTypeSpot);

                return;
            }

            itemTypeSpot.Set(request.ViewModel.SpotId);

            await _itemTypeSpotRepository.Update(itemTypeSpot);
        }
    }
}
