namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveItemTypeGameStyle(ItemTypeGameStyleEditModel ItemTypeGameStyle) : ICommand
{
    public class Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository) 
        : CommandHandler<SaveItemTypeGameStyle>
    {
        protected override async Task Handle(SaveItemTypeGameStyle request)
        {
            Entity.ItemTypeGameStyleType itemTypeGameStyle;

            if (request.ItemTypeGameStyle.IsNew)
            {
                itemTypeGameStyle = new Entity.ItemTypeGameStyleType(request.ItemTypeGameStyle.ItemType.Id, 
                                                                     request.ItemTypeGameStyle.GameStyleTypeId);

                await itemTypeGameStyleRepository.Add(itemTypeGameStyle);

                return;
            }

            itemTypeGameStyle = await itemTypeGameStyleRepository.Get(request.ItemTypeGameStyle.Id);

            if (request.ItemTypeGameStyle.IsDeleted)
            {
                await itemTypeGameStyleRepository.Delete(itemTypeGameStyle);

                return;
            }

            itemTypeGameStyle.Set(request.ItemTypeGameStyle.GameStyleTypeId);

            await itemTypeGameStyleRepository.Update(itemTypeGameStyle);
        }
    }
}
