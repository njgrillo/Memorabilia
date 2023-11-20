namespace Memorabilia.Blazor.Pages.Team;

public partial class MultiTeamSelector
{
    [Parameter]
    public ItemType ItemType { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    [Parameter]
    public List<TeamEditModel> SelectedTeams { get; set; }

    [Parameter]
    public EventCallback<List<TeamEditModel>> SelectedTeamsChanged { get; set; }

    protected TeamEditModel SelectedTeam { get; set; }

    private void Add()
    {
        TeamEditModel team = SelectedTeams.SingleOrDefault(team => team.Id == SelectedTeam.Id);

        if (team != null)
            team.IsDeleted = false;
        else
        {
            SelectedTeams.Add(SelectedTeam);
            SelectedTeamsChanged.InvokeAsync(SelectedTeams);
        }

        SelectedTeam = new();
    }
}
