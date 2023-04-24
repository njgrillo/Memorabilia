namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class LeadersProfile : SportProfile
{
    private LeaderProfileViewModel[] Leaders = Array.Empty<LeaderProfileViewModel>();
    private string _search;

    protected override void OnParametersSet()
    {
        Leaders = Person.Leaders
                        .Filter(Sport, OccupationType)
                        .Select(leader => new LeaderProfileViewModel(leader))
                        .OrderBy(leader => leader.Year)
                        .ThenBy(leader => leader.LeaderTypeName)
                        .ToArray();
    }

    private bool FilterFunc1(LeaderProfileViewModel viewModel)
        => FilterFunc(viewModel, _search);

    private static bool FilterFunc(LeaderProfileViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.LeaderTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.LeaderTypeAbbreviatedName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
