

namespace Memorabilia.Blazor.Controls.Team;

public partial class SearchTeamSelector : ComponentBase
{
    [Parameter]
    public List<Domain.Entities.Team> SelectedTeams { get; set; }

    [Parameter]
    public EventCallback<List<Domain.Entities.Team>> SelectedTeamsChanged { get; set; }

    protected Domain.Entities.Team SelectedTeam { get; set; }    

    private void Add()
    {
        if (SelectedTeam.Id == 0)
            return;

        var team = SelectedTeams.SingleOrDefault(team => team.Id == SelectedTeam.Id);

        if (team == null)
        {
            SelectedTeams.Add(SelectedTeam);
            SelectedTeamsChanged.InvokeAsync(SelectedTeams);
        }

        SelectedTeam = new();
    }

    private void RemoveTeam(Domain.Entities.Team team)
    {
        var removedTeam = SelectedTeams.SingleOrDefault(t => t.Id == team.Id);

        if (removedTeam != null)
        {
            SelectedTeams.Remove(removedTeam);
        }
    }
}
