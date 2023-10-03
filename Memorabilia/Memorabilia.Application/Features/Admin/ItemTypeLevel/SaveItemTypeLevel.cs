namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveItemTypeLevel(ItemTypeLevelEditModel ItemTypeLevel) : ICommand
{
    public class Handler : CommandHandler<SaveItemTypeLevel>
    {
        private readonly IItemTypeLevelRepository _itemTypeLevelRepository;

        public Handler(IItemTypeLevelRepository itemTypeLevelRepository)
        {
            _itemTypeLevelRepository = itemTypeLevelRepository;
        }

        protected override async Task Handle(SaveItemTypeLevel request)
        {
            Entity.ItemTypeLevel itemTypeLevel;

            if (request.ItemTypeLevel.IsNew)
            {
                itemTypeLevel = new Entity.ItemTypeLevel(request.ItemTypeLevel.ItemType.Id, 
                                                         request.ItemTypeLevel.LevelTypeId);

                await _itemTypeLevelRepository.Add(itemTypeLevel);

                return;
            }

            itemTypeLevel = await _itemTypeLevelRepository.Get(request.ItemTypeLevel.Id);

            if (request.ItemTypeLevel.IsDeleted)
            {
                await _itemTypeLevelRepository.Delete(itemTypeLevel);

                return;
            }

            itemTypeLevel.Set(request.ItemTypeLevel.LevelTypeId);

            await _itemTypeLevelRepository.Update(itemTypeLevel);
        }
    }
}
