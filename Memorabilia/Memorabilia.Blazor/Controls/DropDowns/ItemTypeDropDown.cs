
namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeDropDown : DropDown<ItemType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = ItemType.All;
        Label = "Item Type";
    }
}
