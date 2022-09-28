using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypes
{
    public class SaveItemType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IItemTypeRepository _itemTypeRepository;

            public Handler(IItemTypeRepository itemTypeRepository)
            {
                _itemTypeRepository = itemTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                ItemType itemType;

                if (command.IsNew)
                {
                    itemType = new ItemType(command.Name, command.Abbreviation);
                    await _itemTypeRepository.Add(itemType).ConfigureAwait(false);

                    return;
                }

                itemType = await _itemTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _itemTypeRepository.Delete(itemType).ConfigureAwait(false);

                    return;
                }

                itemType.Set(command.Name, command.Abbreviation);

                await _itemTypeRepository.Update(itemType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
