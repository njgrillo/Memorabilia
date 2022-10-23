namespace Memorabilia.Blazor.Controls.DropDowns;

public class SpotDropDown : DropDown<Spot, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
    {
        return !selectedValues.Any() || selectedValues.Count > 3
            ? $"{selectedValues.Count} spots selected"
            : string.Join(", ", selectedValues.Select(item => Spot.Find(item.ToInt32())?.Name));
    }

    protected override void OnInitialized()
    {
        Items = Spot.All;
        Label = "Spot";
    }
}
