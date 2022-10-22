namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeSizeDropDown : ItemTypeEntityDropDown<ItemTypeSizeViewModel>
{
    protected override async Task OnInitializedAsync()
    {
        Items = (await QueryRouter.Send(new GetItemTypeSizes(ItemType.Id))).ItemTypeSizes;
        Label = "Size";
    }
}
