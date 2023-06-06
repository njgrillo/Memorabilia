namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class AwardsProfile : PersonProfile
{
    [Parameter]
    public Sport Sport { get; set; }

    private AwardProfileModel[] Awards = Array.Empty<AwardProfileModel>();
    private string _search;

    protected override void OnParametersSet()
    {
        Awards = Person.Awards
                       .Filter(Sport, OccupationType)
                       .Select(award => new AwardProfileModel(award))
                       .OrderBy(award => award.Year)
                       .ThenBy(award => award.AwardTypeName)
                       .ToArray();
    }

    private bool FilterFunc1(AwardProfileModel viewModel)
        => FilterFunc(viewModel, _search);

    private static bool FilterFunc(AwardProfileModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.AwardTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.AwardTypeAbbreviatedName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
