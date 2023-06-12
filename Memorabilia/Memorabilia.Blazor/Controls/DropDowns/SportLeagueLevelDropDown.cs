namespace Memorabilia.Blazor.Controls.DropDowns;

public class SportLeagueLevelDropDown : DropDown<SportLeagueLevel, int>
{
    [Parameter]
    public bool IsConference { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    protected override string GetMultiSelectionText(List<string> selectedValues)
        => !selectedValues.Any() || selectedValues.Count > 3
            ? $"{selectedValues.Count} sport league levels selected"
            : string.Join(", ", selectedValues.Select(item => SportLeagueLevel.Find(item.ToInt32())?.Name));

    protected override void OnInitialized()
    {
        Items = Sport != null
            ? SportLeagueLevel.GetAll(Sport.Id)
            : !IsConference
                ? SportLeagueLevel.All
                : SportLeagueLevel.Conference;

        Label = "Sport League Level";
    }
}
