namespace Memorabilia.Blazor.Controls.DropDowns;

public class PurchaseTypeDropDown : DropDown<PurchaseType, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
    => !selectedValues.Any() || selectedValues.Count > 4 
        ? $"{selectedValues.Count} purchase types selected" 
        : string.Join(", ", selectedValues.Select(item => PurchaseType.Find(item.ToInt32())?.Name));

    protected override void OnInitialized()
    {
        Items = PurchaseType.All;
        Label = "Purchase Type";
    }
}
