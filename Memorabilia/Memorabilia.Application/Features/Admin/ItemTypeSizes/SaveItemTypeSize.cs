namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveItemTypeSize(ItemTypeSizeEditModel ItemTypeSize) : ICommand
{
    public class Handler(IItemTypeSizeRepository itemTypeSizeRepository) 
        : CommandHandler<SaveItemTypeSize>
    {
        protected override async Task Handle(SaveItemTypeSize request)
        {
            Entity.ItemTypeSize itemTypeSize;

            if (request.ItemTypeSize.IsNew)
            {
                itemTypeSize = new Entity.ItemTypeSize(request.ItemTypeSize.ItemType.Id, 
                                                       request.ItemTypeSize.Size.Id);

                await itemTypeSizeRepository.Add(itemTypeSize);

                return;
            }

            itemTypeSize = await itemTypeSizeRepository.Get(request.ItemTypeSize.Id);

            if (request.ItemTypeSize.IsDeleted)
            {
                await itemTypeSizeRepository.Delete(itemTypeSize);

                return;
            }

            itemTypeSize.Set(request.ItemTypeSize.Size.Id);

            await itemTypeSizeRepository.Update(itemTypeSize);
        }
    }
}
