using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeLevel
{
    public class SaveItemTypeLevel
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IItemTypeLevelRepository _itemTypeLevelRepository;

            public Handler(IItemTypeLevelRepository itemTypeLevelRepository)
            {
                _itemTypeLevelRepository = itemTypeLevelRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.ItemTypeLevel itemTypeLevel;

                if (command.IsNew)
                {
                    itemTypeLevel = new Domain.Entities.ItemTypeLevel(command.ItemTypeId, command.LevelTypeId);

                    await _itemTypeLevelRepository.Add(itemTypeLevel).ConfigureAwait(false);

                    return;
                }

                itemTypeLevel = await _itemTypeLevelRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _itemTypeLevelRepository.Delete(itemTypeLevel).ConfigureAwait(false);

                    return;
                }

                itemTypeLevel.Set(command.LevelTypeId);

                await _itemTypeLevelRepository.Update(itemTypeLevel).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveItemTypeLevelViewModel _viewModel;

            public Command(SaveItemTypeLevelViewModel viewModel)
            {
                _viewModel = viewModel;
            }            

            public int Id => _viewModel.Id;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public int ItemTypeId => _viewModel.ItemTypeId;

            public int LevelTypeId => _viewModel.LevelTypeId;
        }
    }
}
