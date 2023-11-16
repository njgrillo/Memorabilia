namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class AwardsProfile : PersonProfile
{
    [Parameter]
    public Sport Sport { get; set; }

    private AwardProfileModel[] Awards 
        = [];

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

    private bool FilterFunc1(AwardProfileModel model)
        => FilterFunc(model, _search);

    private static bool FilterFunc(AwardProfileModel model, string search)
    {
        return search.IsNullOrEmpty() ||
               model.AwardTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               model.AwardTypeAbbreviatedName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
