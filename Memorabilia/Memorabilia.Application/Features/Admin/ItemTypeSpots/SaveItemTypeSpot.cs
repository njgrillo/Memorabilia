using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpots;

public class SaveItemTypeSpot
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IItemTypeSpotRepository _itemTypeSpotRepository;

        public Handler(IItemTypeSpotRepository itemTypeSpotRepository)
        {
            _itemTypeSpotRepository = itemTypeSpotRepository;
        }

        protected override async Task Handle(Command command)
        {
            ItemTypeSpot itemTypeSpot;

            if (command.IsNew)
            {
                itemTypeSpot = new ItemTypeSpot(command.ItemTypeId, command.SpotId);

                await _itemTypeSpotRepository.Add(itemTypeSpot);

                return;
            }

            itemTypeSpot = await _itemTypeSpotRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _itemTypeSpotRepository.Delete(itemTypeSpot);

                return;
            }

            itemTypeSpot.Set(command.SpotId);

            await _itemTypeSpotRepository.Update(itemTypeSpot);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveItemTypeSpotViewModel _viewModel;

        public Command(SaveItemTypeSpotViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int Id => _viewModel.Id;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public int ItemTypeId => _viewModel.ItemTypeId;

        public int SpotId => _viewModel.SpotId;
    }
}
