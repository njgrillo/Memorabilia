namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class TeamsProfile : SportProfile
{
    private TeamProfileModel[] Teams 
        = []; 

    protected override void OnParametersSet()
    {
        Teams = Person.Teams
                      .Filter(Sport, OccupationType)
                      .Select(team => new TeamProfileModel(team))
                      .ToArray();
    }
}
