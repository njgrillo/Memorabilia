namespace Memorabilia.Blazor.Controls.DropDowns;

public class ChampionshipTypeDropDown : DropDown<ChampionType, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override void OnInitialized()
    {
        Label = "Championship Type";
        Items = new ChampionType[] { ChampionType.Find(SportLeagueLevel) };
    }
}
