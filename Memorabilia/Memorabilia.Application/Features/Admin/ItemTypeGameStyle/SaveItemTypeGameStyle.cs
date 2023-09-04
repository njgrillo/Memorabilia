namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveItemTypeGameStyle(ItemTypeGameStyleEditModel ItemTypeGameStyle) : ICommand
{
    public class Handler : CommandHandler<SaveItemTypeGameStyle>
    {
        private readonly IItemTypeGameStyleTypeRepository _itemTypeGameStyleRepository;

        public Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository)
        {
            _itemTypeGameStyleRepository = itemTypeGameStyleRepository;
        }

        protected override async Task Handle(SaveItemTypeGameStyle request)
        {
            Entity.ItemTypeGameStyleType itemTypeGameStyle;

            if (request.ItemTypeGameStyle.IsNew)
            {
                itemTypeGameStyle = new Entity.ItemTypeGameStyleType(request.ItemTypeGameStyle.ItemType.Id, 
                                                                     request.ItemTypeGameStyle.GameStyleTypeId);

                await _itemTypeGameStyleRepository.Add(itemTypeGameStyle);

                return;
            }

            itemTypeGameStyle = await _itemTypeGameStyleRepository.Get(request.ItemTypeGameStyle.Id);

            if (request.ItemTypeGameStyle.IsDeleted)
            {
                await _itemTypeGameStyleRepository.Delete(itemTypeGameStyle);

                return;
            }

            itemTypeGameStyle.Set(request.ItemTypeGameStyle.GameStyleTypeId);

            await _itemTypeGameStyleRepository.Update(itemTypeGameStyle);
        }
    }
}
