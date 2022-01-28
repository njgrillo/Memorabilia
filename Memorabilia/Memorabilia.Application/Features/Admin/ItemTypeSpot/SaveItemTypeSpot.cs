using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpot
{
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
                Domain.Entities.ItemTypeSpot itemTypeSpot;

                if (command.IsNew)
                {
                    itemTypeSpot = new Domain.Entities.ItemTypeSpot(command.ItemTypeId, command.SpotId);

                    await _itemTypeSpotRepository.Add(itemTypeSpot).ConfigureAwait(false);

                    return;
                }

                itemTypeSpot = await _itemTypeSpotRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _itemTypeSpotRepository.Delete(itemTypeSpot).ConfigureAwait(false);

                    return;
                }

                itemTypeSpot.Set(command.SpotId);

                await _itemTypeSpotRepository.Update(itemTypeSpot).ConfigureAwait(false);
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
}
