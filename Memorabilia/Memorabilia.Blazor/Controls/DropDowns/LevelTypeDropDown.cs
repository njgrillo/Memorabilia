namespace Memorabilia.Blazor.Controls.DropDowns;

public class LevelTypeDropDown : DropDown<LevelType, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
        => selectedValues.Count == 0 || selectedValues.Count > 4
            ? $"{selectedValues.Count} level types selected"
            : string.Join(", ", selectedValues.Select(item => LevelType.Find(item.ToInt32())?.Name));

    protected override void OnInitialized()
    {
        Items = LevelType.All;
        Label = "Level Type";
    }
}
