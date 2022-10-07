using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypes;

public class SaveItemType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            ItemType itemType;

            if (command.IsNew)
            {
                itemType = new ItemType(command.Name, command.Abbreviation);

                await _itemTypeRepository.Add(itemType);

                return;
            }

            itemType = await _itemTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _itemTypeRepository.Delete(itemType);

                return;
            }

            itemType.Set(command.Name, command.Abbreviation);

            await _itemTypeRepository.Update(itemType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
