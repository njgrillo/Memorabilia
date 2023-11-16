namespace Memorabilia.Blazor.Controls.DropDowns;

public class GameStyleTypeDropDown : DropDown<GameStyleType, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
    => selectedValues.Count == 0 || selectedValues.Count > 4 
        ? $"{selectedValues.Count} game style types selected" 
        : string.Join(", ", selectedValues.Select(item => GameStyleType.Find(item.ToInt32())?.Name));

    protected override void OnInitialized()
    {
        Items = GameStyleType.All;
        Label = "Game Style Type";
    }
}
