namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeDropDown : DropDown<ItemType, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
        => !selectedValues.Any() || selectedValues.Count > 4
            ? $"{selectedValues.Count} item types selected"
            : string.Join(", ", selectedValues.Select(item => ItemType.Find(item.ToInt32())?.Name));

    protected override void OnInitialized()
    {
        Items = ItemType.All;
        Label = "Item Type";
    }
}
