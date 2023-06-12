namespace Memorabilia.Blazor.Controls.DropDowns;

public class LeagueDropDown : DropDown<League, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override void OnInitialized()
    {
        Items = SportLeagueLevel != null 
            ? League.GetAll(SportLeagueLevel) 
            : League.All;

        Label = "League";
    }
}
