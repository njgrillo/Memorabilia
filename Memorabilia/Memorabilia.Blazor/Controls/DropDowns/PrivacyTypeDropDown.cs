namespace Memorabilia.Blazor.Controls.DropDowns;

public class PrivacyTypeDropDown : DropDown<PrivacyType, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
    => !selectedValues.Any() || selectedValues.Count > 4 
        ? $"{selectedValues.Count} privacy types selected" 
        : string.Join(", ", selectedValues.Select(item => PrivacyType.Find(item.ToInt32())?.Name));

    protected override void OnInitialized()
    {
        Items = PrivacyType.All;
        Label = "Privacy Type";
    }
}
