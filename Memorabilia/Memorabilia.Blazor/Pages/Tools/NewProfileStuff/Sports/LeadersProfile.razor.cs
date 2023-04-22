namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class LeadersProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private LeaderProfileViewModel[] Leaders = Array.Empty<LeaderProfileViewModel>();

    protected override void OnParametersSet()
    {
        Leaders = Person.Leaders
                        .Filter(Sport)
                        .Select(leader => new LeaderProfileViewModel(leader))
                        .OrderBy(leader => leader.Year)
                        .ThenBy(leader => leader.LeaderTypeName)
                        .ToArray();
    }
}
