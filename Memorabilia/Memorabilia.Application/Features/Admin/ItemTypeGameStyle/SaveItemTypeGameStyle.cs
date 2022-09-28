namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle
{
    public class SaveItemTypeGameStyle
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IItemTypeGameStyleTypeRepository _itemTypeGameStyleRepository;

            public Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository)
            {
                _itemTypeGameStyleRepository = itemTypeGameStyleRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.ItemTypeGameStyleType itemTypeGameStyle;

                if (command.IsNew)
                {
                    itemTypeGameStyle = new Domain.Entities.ItemTypeGameStyleType(command.ItemTypeId, command.GameStyleTypeId);

                    await _itemTypeGameStyleRepository.Add(itemTypeGameStyle).ConfigureAwait(false);

                    return;
                }

                itemTypeGameStyle = await _itemTypeGameStyleRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _itemTypeGameStyleRepository.Delete(itemTypeGameStyle).ConfigureAwait(false);

                    return;
                }

                itemTypeGameStyle.Set(command.GameStyleTypeId);

                await _itemTypeGameStyleRepository.Update(itemTypeGameStyle).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveItemTypeGameStyleViewModel _viewModel;

            public Command(SaveItemTypeGameStyleViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int GameStyleTypeId => _viewModel.GameStyleTypeId;

            public int Id => _viewModel.Id;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public int ItemTypeId => _viewModel.ItemTypeId;
        }
    }
}
