namespace Memorabilia.Blazor.Controls.DropDowns;

public class SportDropDown : DropDown<Sport, int>
{
    [Parameter]
    public ItemType ItemType { get; set; }

    private ItemType _itemType;
    private bool _loaded;

    protected override string GetMultiSelectionText(List<string> selectedValues)
        => selectedValues.IsNullOrEmpty() || selectedValues.Count > 4
            ? $"{selectedValues.Count} sports selected"
            : string.Join(", ", selectedValues.Select(item => Sport.Find(item.ToInt32())?.Name));

    protected override void OnInitialized()
    {
        Label = "Sport";

        SetItems();
    }

    protected override void OnParametersSet()
    {
        SetItems();
    }

    private void SetItems()
    {
        if (_loaded && _itemType == ItemType)
            return;

        Items = ItemType != null 
            ? Sport.GetAll(ItemType) 
            : Sport.All;

        _itemType = ItemType;
        _loaded = true;
    }
}
