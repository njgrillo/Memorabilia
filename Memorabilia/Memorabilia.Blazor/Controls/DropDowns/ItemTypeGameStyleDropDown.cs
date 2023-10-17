namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeGameStyleDropDown 
    : ItemTypeEntityDropDown<ItemTypeGameStyleModel>
{
    protected override async Task OnInitializedAsync()
    {
        Entity.ItemTypeGameStyleType[] itemTypeGameStyleTypes 
            = await Mediator.Send(new GetItemTypeGameStyles(ItemType.Id));

        Items
            = itemTypeGameStyleTypes.Select(itemTypeGameStyleType => new ItemTypeGameStyleModel(itemTypeGameStyleType));
    }
}
