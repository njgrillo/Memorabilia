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

    private bool Filter(AwardProfileModel model)
        => model.Filter(_search);
}
