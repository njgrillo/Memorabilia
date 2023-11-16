namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeBrandDropDown 
    : ItemTypeEntityDropDown<ItemTypeBrandModel>
{
    protected override async Task OnInitializedAsync()
    {
        Entity.ItemTypeBrand[] itemTypeBrands = await Mediator.Send(new GetItemTypeBrands(ItemType.Id));

        Items = itemTypeBrands.Select(itemTypeBrand => new ItemTypeBrandModel(itemTypeBrand));
        Label = "Brand";
    }
}
