namespace Memorabilia.Application.Features.Admin.ItemTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveItemType(DomainEditModel ItemType) : ICommand
{
    public class Handler(IDomainRepository<Entity.ItemType> itemTypeRepository) 
        : CommandHandler<SaveItemType>
    {
        protected override async Task Handle(SaveItemType request)
        {
            Entity.ItemType itemType;

            if (request.ItemType.IsNew)
            {
                itemType = new Entity.ItemType(request.ItemType.Name, 
                                               request.ItemType.Abbreviation);

                await itemTypeRepository.Add(itemType);

                return;
            }

            itemType = await itemTypeRepository.Get(request.ItemType.Id);

            if (request.ItemType.IsDeleted)
            {
                await itemTypeRepository.Delete(itemType);

                return;
            }

            itemType.Set(request.ItemType.Name, 
                         request.ItemType.Abbreviation);

            await itemTypeRepository.Update(itemType);
        }
    }
}
