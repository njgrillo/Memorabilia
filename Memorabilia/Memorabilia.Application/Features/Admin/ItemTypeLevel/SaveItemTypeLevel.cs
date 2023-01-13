namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public record SaveItemTypeLevel(SaveItemTypeLevelViewModel ViewModel) : ICommand
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
            Domain.Entities.ItemTypeLevel itemTypeLevel;

            if (request.ViewModel.IsNew)
            {
                itemTypeLevel = new Domain.Entities.ItemTypeLevel(request.ViewModel.ItemType.Id, request.ViewModel.LevelTypeId);

                await _itemTypeLevelRepository.Add(itemTypeLevel);

                return;
            }

            itemTypeLevel = await _itemTypeLevelRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _itemTypeLevelRepository.Delete(itemTypeLevel);

                return;
            }

            itemTypeLevel.Set(request.ViewModel.LevelTypeId);

            await _itemTypeLevelRepository.Update(itemTypeLevel);
        }
    }
}
