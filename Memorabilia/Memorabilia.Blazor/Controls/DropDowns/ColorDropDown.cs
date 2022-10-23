#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public class ColorDropDown : DropDown<Domain.Constants.Color, int>
{
    [Parameter]
    public ItemType ItemType { get; set; }

    protected override string GetMultiSelectionText(List<string> selectedValues)
    {
        return !selectedValues.Any() || selectedValues.Count > 4
            ? $"{selectedValues.Count} colors selected"
            : string.Join(", ", selectedValues.Select(item => Domain.Constants.Color.Find(item.ToInt32())?.Name));
    }

    protected override void OnInitialized()
    {
        Items = Domain.Constants.Color.GetAll(ItemType);
        Label = "Color";
    }
}
