using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public class SaveItemTypeSize
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IItemTypeSizeRepository _itemTypeSizeRepository;

        public Handler(IItemTypeSizeRepository itemTypeSizeRepository)
        {
            _itemTypeSizeRepository = itemTypeSizeRepository;
        }

        protected override async Task Handle(Command command)
        {
            ItemTypeSize itemTypeSize;

            if (command.IsNew)
            {
                itemTypeSize = new ItemTypeSize(command.ItemTypeId, command.SizeId);

                await _itemTypeSizeRepository.Add(itemTypeSize);

                return;
            }

            itemTypeSize = await _itemTypeSizeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _itemTypeSizeRepository.Delete(itemTypeSize);

                return;
            }

            itemTypeSize.Set(command.SizeId);

            await _itemTypeSizeRepository.Update(itemTypeSize);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveItemTypeSizeViewModel _viewModel;

        public Command(SaveItemTypeSizeViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int Id => _viewModel.Id;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public int ItemTypeId => _viewModel.ItemTypeId;

        public int SizeId => _viewModel.SizeId;
    }
}
