namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class TeamsProfile : SportProfile
{
    private TeamProfileViewModel[] Teams = Array.Empty<TeamProfileViewModel>(); 

    protected override void OnParametersSet()
    {
        Teams = Person.Teams
                      .Filter(Sport, OccupationType)
                      .Select(team => new TeamProfileViewModel(team))
                      .ToArray();
    }
}
