namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveItemTypeLevel(ItemTypeLevelEditModel ItemTypeLevel) : ICommand
{
    public class Handler(IItemTypeLevelRepository itemTypeLevelRepository) 
        : CommandHandler<SaveItemTypeLevel>
    {
        protected override async Task Handle(SaveItemTypeLevel request)
        {
            Entity.ItemTypeLevel itemTypeLevel;

            if (request.ItemTypeLevel.IsNew)
            {
                itemTypeLevel = new Entity.ItemTypeLevel(request.ItemTypeLevel.ItemType.Id, 
                                                         request.ItemTypeLevel.LevelTypeId);

                await itemTypeLevelRepository.Add(itemTypeLevel);

                return;
            }

            itemTypeLevel = await itemTypeLevelRepository.Get(request.ItemTypeLevel.Id);

            if (request.ItemTypeLevel.IsDeleted)
            {
                await itemTypeLevelRepository.Delete(itemTypeLevel);

                return;
            }

            itemTypeLevel.Set(request.ItemTypeLevel.LevelTypeId);

            await itemTypeLevelRepository.Update(itemTypeLevel);
        }
    }
}
