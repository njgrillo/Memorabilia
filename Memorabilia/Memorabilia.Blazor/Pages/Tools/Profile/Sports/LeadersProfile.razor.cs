namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class LeadersProfile : SportProfile
{
    private LeaderProfileModel[] Leaders
        = [];

    private string _search;

    protected override void OnParametersSet()
    {
        Leaders = Person.Leaders
                        .Filter(Sport, OccupationType)
                        .Select(leader => new LeaderProfileModel(leader))
                        .OrderBy(leader => leader.Year)
                        .ThenBy(leader => leader.LeaderTypeName)
                        .ToArray();
    }

    private bool FilterFunc1(LeaderProfileModel model)
        => FilterFunc(model, _search);

    private static bool FilterFunc(LeaderProfileModel model, string search)
    {
        return search.IsNullOrEmpty() ||
               model.LeaderTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               model.LeaderTypeAbbreviatedName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
