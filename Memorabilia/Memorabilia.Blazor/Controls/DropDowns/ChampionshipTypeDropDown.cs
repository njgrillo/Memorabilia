namespace Memorabilia.Blazor.Controls.DropDowns;

public class ChampionshipTypeDropDown : DropDown<ChampionType, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private SportLeagueLevel _sportLeagueLevel;

    protected override void OnInitialized()
    {
        Label = "Championship Type";
    }

    protected override void OnParametersSet()
    {
        if (_sportLeagueLevel == null || (SportLeagueLevel != null && _sportLeagueLevel == SportLeagueLevel))
            return;

        Items = new ChampionType[] { ChampionType.Find(SportLeagueLevel) };

        _sportLeagueLevel = SportLeagueLevel;
    }
}
