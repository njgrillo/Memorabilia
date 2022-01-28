using Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.ItemType
{
    public class SaveItemType
    {
        public class Handler : CommandHandler<DomainEntityCommand>
        {
            private readonly IItemTypeRepository _itemTypeRepository;

            public Handler(IItemTypeRepository itemTypeRepository)
            {
                _itemTypeRepository = itemTypeRepository;
            }

            protected override async Task Handle(DomainEntityCommand command)
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
    }
}
