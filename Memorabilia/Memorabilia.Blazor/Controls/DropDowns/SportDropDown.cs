namespace Memorabilia.Blazor.Controls.DropDowns;

public class SportDropDown : DropDown<Domain.Constants.Sport, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
    {
        return !selectedValues.Any() || selectedValues.Count > 4 
            ? $"{selectedValues.Count} sports selected"
            : string.Join(", ", selectedValues.Select(item => Domain.Constants.Sport.Find(item.ToInt32())?.Name));
    }

    protected override void OnInitialized()
    {
        Items = Domain.Constants.Sport.All;
        Label = "Sport";
    }
}
