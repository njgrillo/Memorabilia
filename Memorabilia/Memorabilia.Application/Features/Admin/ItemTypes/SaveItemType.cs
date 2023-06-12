namespace Memorabilia.Application.Features.Admin.ItemTypes;

public record SaveItemType(DomainEditModel ItemType) : ICommand
{
    public class Handler : CommandHandler<SaveItemType>
    {
        private readonly IDomainRepository<Entity.ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<Entity.ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task Handle(SaveItemType request)
        {
            Entity.ItemType itemType;

            if (request.ItemType.IsNew)
            {
                itemType = new Entity.ItemType(request.ItemType.Name, 
                                               request.ItemType.Abbreviation);

                await _itemTypeRepository.Add(itemType);

                return;
            }

            itemType = await _itemTypeRepository.Get(request.ItemType.Id);

            if (request.ItemType.IsDeleted)
            {
                await _itemTypeRepository.Delete(itemType);

                return;
            }

            itemType.Set(request.ItemType.Name, 
                         request.ItemType.Abbreviation);

            await _itemTypeRepository.Update(itemType);
        }
    }
}
