using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeAuthenticType
{
    public class SaveItemTypeAuthenticType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IItemTypeAuthenticTypeRepository _itemTypeAuthenticTypeRepository;

            public Handler(IItemTypeAuthenticTypeRepository itemTypeAuthenticTypeRepository)
            {
                _itemTypeAuthenticTypeRepository = itemTypeAuthenticTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.ItemTypeAuthenticType itemTypeAuthenticType;

                if (command.IsNew)
                {
                    itemTypeAuthenticType = new Domain.Entities.ItemTypeAuthenticType(command.ItemTypeId, command.AuthenticTypeId);

                    await _itemTypeAuthenticTypeRepository.Add(itemTypeAuthenticType).ConfigureAwait(false);

                    return;
                }

                itemTypeAuthenticType = await _itemTypeAuthenticTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _itemTypeAuthenticTypeRepository.Delete(itemTypeAuthenticType).ConfigureAwait(false);

                    return;
                }

                itemTypeAuthenticType.Set(command.AuthenticTypeId);

                await _itemTypeAuthenticTypeRepository.Update(itemTypeAuthenticType).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveItemTypeAuthenticTypeViewModel _viewModel;

            public Command(SaveItemTypeAuthenticTypeViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int AuthenticTypeId => _viewModel.AuthenticTypeId;

            public int Id => _viewModel.Id;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public int ItemTypeId => _viewModel.ItemTypeId;
        }
    }
}
