namespace Memorabilia.Blazor.Controls.DropDowns;

public class SportLeagueLevelDropDown : DropDown<SportLeagueLevel, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = SportLeagueLevel.All;
        Label = "Sport League Level";
    }
}
