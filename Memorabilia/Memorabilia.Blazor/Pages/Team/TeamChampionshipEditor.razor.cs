namespace Memorabilia.Blazor.Pages.Team;

public partial class TeamChampionshipEditor
{
    [Parameter]
    public List<TeamChampionshipEditModel> Championships { get; set; } 
        = [];

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private TeamChampionshipEditModel Model        
        = new();

    private string _years;

    private void Add()
    {
        foreach (int year in _years.ToIntArray())
        {
            Championships.Add(new() 
                                { ChampionshipTypeId = Model.ChampionshipTypeId, 
                                  TeamId = Model.TeamId,
                                  Year = year 
                                });
        }

        Model = new();
        _years = string.Empty;
    }
}
