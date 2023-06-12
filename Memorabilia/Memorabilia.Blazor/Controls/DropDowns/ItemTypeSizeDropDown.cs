namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeSizeDropDown : ItemTypeEntityDropDown<ItemTypeSizeModel>
{
    protected override async Task OnInitializedAsync()
    {
        Entity.ItemTypeSize[] itemTypeSizes = await QueryRouter.Send(new GetItemTypeSizes(ItemType.Id));

        Items = itemTypeSizes.Select(itemTypeSize => new ItemTypeSizeModel(itemTypeSize));
        Label = "Size";
    }
}
