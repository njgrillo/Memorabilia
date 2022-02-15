using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemType
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
                Domain.Entities.ItemType itemType;

                if (command.IsNew)
                {
                    itemType = new Domain.Entities.ItemType(command.Name, command.Abbreviation);
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
