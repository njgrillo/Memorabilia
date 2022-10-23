namespace Memorabilia.Blazor.Controls.DropDowns;

public class ConditionDropDown : DropDown<Condition, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
    {
        return !selectedValues.Any() || selectedValues.Count > 4
            ? $"{selectedValues.Count} conditions selected"
            : string.Join(", ", selectedValues.Select(item => Condition.Find(item.ToInt32())?.Name));
    }

    protected override void OnInitialized()
    {
        Items = Condition.All;
        Label = "Condition";
    }
}
