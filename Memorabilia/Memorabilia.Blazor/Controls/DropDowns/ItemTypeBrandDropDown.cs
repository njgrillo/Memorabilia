namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeBrandDropDown : ItemTypeEntityDropDown<ItemTypeBrandViewModel>
{
    protected override async Task OnInitializedAsync()
    {
        Items = (await QueryRouter.Send(new GetItemTypeBrands(ItemType.Id))).ItemTypeBrands;
        Label = "Brand";
    }
}
