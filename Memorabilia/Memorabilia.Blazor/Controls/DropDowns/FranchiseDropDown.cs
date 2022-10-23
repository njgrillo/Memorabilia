namespace Memorabilia.Blazor.Controls.DropDowns;

public class FranchiseDropDown : DropDown<Franchise, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
    {
        return !selectedValues.Any() || selectedValues.Count > 4
            ? $"{selectedValues.Count} franchises selected"
            : string.Join(", ", selectedValues.Select(item => Franchise.Find(item.ToInt32())?.Name));
    }

    protected override void OnInitialized()
    {
        Items = Franchise.All;
        Label = "Franchise";
    }
}
