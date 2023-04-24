namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public partial class AwardsProfile : PersonProfile
{
    [Parameter]
    public Sport Sport { get; set; }

    private AwardProfileViewModel[] Awards = Array.Empty<AwardProfileViewModel>();
    private string _search;

    protected override void OnParametersSet()
    {
        Awards = Person.Awards
                       .Filter(Sport, OccupationType)
                       .Select(award => new AwardProfileViewModel(award))
                       .OrderBy(award => award.Year)
                       .ThenBy(award => award.AwardTypeName)
                       .ToArray();
    }

    private bool FilterFunc1(AwardProfileViewModel viewModel)
        => FilterFunc(viewModel, _search);

    private static bool FilterFunc(AwardProfileViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.AwardTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.AwardTypeAbbreviatedName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
