using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public class SaveItemTypeSport
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IItemTypeSportRepository _itemTypeSportRepository;

        public Handler(IItemTypeSportRepository itemTypeSportRepository)
        {
            _itemTypeSportRepository = itemTypeSportRepository;
        }

        protected override async Task Handle(Command command)
        {
            ItemTypeSport itemTypeSport;

            if (command.IsNew)
            {
                itemTypeSport = new ItemTypeSport(command.ItemTypeId, command.SportId);

                await _itemTypeSportRepository.Add(itemTypeSport);

                return;
            }

            itemTypeSport = await _itemTypeSportRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _itemTypeSportRepository.Delete(itemTypeSport);

                return;
            }

            itemTypeSport.Set(command.SportId);

            await _itemTypeSportRepository.Update(itemTypeSport);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveItemTypeSportViewModel _viewModel;

        public Command(SaveItemTypeSportViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int Id => _viewModel.Id;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public int ItemTypeId => _viewModel.ItemTypeId;

        public int SportId => _viewModel.SportId;
    }
}
