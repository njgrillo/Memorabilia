namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeSizeDropDown : ItemTypeEntityDropDown<ItemTypeSizeModel>
{
    protected override async Task OnInitializedAsync()
    {
        Entity.ItemTypeSize[] itemTypeSizes 
            = await Mediator.Send(new GetItemTypeSizes(ItemType.Id));

        Items = itemTypeSizes.Select(itemTypeSize => new ItemTypeSizeModel(itemTypeSize));
        Label = "Size";
    }
}
