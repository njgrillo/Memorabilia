namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeGameStyleDropDown : ItemTypeEntityDropDown<ItemTypeGameStyleViewModel>
{
    protected override async Task OnInitializedAsync()
    {
        Items = (await QueryRouter.Send(new GetItemTypeGameStyles(ItemType.Id))).ItemTypeGameStyles;
    }
}
