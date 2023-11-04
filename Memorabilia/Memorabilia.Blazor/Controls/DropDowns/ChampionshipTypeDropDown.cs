namespace Memorabilia.Blazor.Controls.DropDowns;

public class ChampionshipTypeDropDown : DropDown<ChampionType, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override void OnInitialized()
    {
        Items = SportLeagueLevel != null
            ? new ChampionType[] { ChampionType.Find(SportLeagueLevel) }
            : ChampionType.All;

        Label = "Championship Type";
    }
}
