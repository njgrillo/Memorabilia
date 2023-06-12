namespace Memorabilia.Blazor.Pages.Team;

public partial class SearchTeamSelector
{
    [Parameter]
    public List<Entity.Team> SelectedTeams { get; set; }

    [Parameter]
    public EventCallback<List<Entity.Team>> SelectedTeamsChanged { get; set; }

    protected Entity.Team SelectedTeam { get; set; }    

    private void Add()
    {
        if (SelectedTeam.Id == 0)
            return;

        Entity.Team team = SelectedTeams.SingleOrDefault(team => team.Id == SelectedTeam.Id);

        if (team == null)
        {
            SelectedTeams.Add(SelectedTeam);
            SelectedTeamsChanged.InvokeAsync(SelectedTeams);
        }

        SelectedTeam = new();
    }

    private void RemoveTeam(Entity.Team team)
    {
        Entity.Team removedTeam = SelectedTeams.SingleOrDefault(t => t.Id == team.Id);

        if (removedTeam != null)
        {
            SelectedTeams.Remove(removedTeam);
        }
    }
}
