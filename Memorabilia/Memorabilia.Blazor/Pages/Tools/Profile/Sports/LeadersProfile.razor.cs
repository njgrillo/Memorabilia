namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class LeadersProfile : SportProfile
{
    private LeaderProfileModel[] Leaders = Array.Empty<LeaderProfileModel>();
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

    private bool FilterFunc1(LeaderProfileModel viewModel)
        => FilterFunc(viewModel, _search);

    private static bool FilterFunc(LeaderProfileModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.LeaderTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.LeaderTypeAbbreviatedName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
