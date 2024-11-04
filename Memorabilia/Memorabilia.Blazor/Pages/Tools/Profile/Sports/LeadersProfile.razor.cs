namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class LeadersProfile : SportProfile
{
    private LeaderProfileModel[] Leaders
        = [];

    protected override void OnParametersSet()
    {
        Leaders = Person.Leaders
                        .Filter(Sport, OccupationType)
                        .Select(leader => new LeaderProfileModel(leader))
                        .OrderBy(leader => leader.Year)
                        .ThenBy(leader => leader.LeaderTypeName)
                        .ToArray();
    }

    private bool Filter(LeaderProfileModel model)
        => model.Filter(Search);
}
