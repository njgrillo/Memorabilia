namespace Memorabilia.Blazor.Controls.DropDowns;

public class SportLeagueLevelDropDown : DropDown<SportLeagueLevel, int>
{
    [Parameter]
    public bool IsConference { get; set; }

    protected override string GetMultiSelectionText(List<string> selectedValues)
    {
        return !selectedValues.Any() || selectedValues.Count > 3
            ? $"{selectedValues.Count} sport league levels selected"
            : string.Join(", ", selectedValues.Select(item => SportLeagueLevel.Find(item.ToInt32())?.Name));
    }

    protected override void OnInitialized()
    {
        Items = !IsConference ? SportLeagueLevel.All : SportLeagueLevel.Conference;
        Label = "Sport League Level";
    }
}
