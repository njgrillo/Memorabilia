namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class TeamsProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Domain.Constants.Sport Sport { get; set; }

    private TeamProfileViewModel[] Teams = Array.Empty<TeamProfileViewModel>(); 

    protected override void OnParametersSet()
    {
        Teams = Person.Teams
                      .Where(team => Sport == null || Sport.Id == team.Team.Franchise.SportLeagueLevel.SportId)
                      .Select(team => new TeamProfileViewModel(team))
                      .ToArray();
    }
}
