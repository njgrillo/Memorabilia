namespace Memorabilia.Blazor.Controls.DropDowns;

public class ColorDropDown : DropDown<Constant.Color, int>
{
    [Parameter]
    public bool DisplayAutographColorsOnly { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }

    protected override string GetMultiSelectionText(List<string> selectedValues)
        => selectedValues.Count == 0 || selectedValues.Count > 4
            ? $"{selectedValues.Count} colors selected"
            : string.Join(", ", selectedValues.Select(item => Constant.Color.Find(item.ToInt32())?.Name));

    protected override void OnInitialized()
    {
        Items = DisplayAutographColorsOnly
            ? Constant.Color.Autograph 
            : Constant.Color.GetAll(ItemType);

        Label = "Color";
    }
}
