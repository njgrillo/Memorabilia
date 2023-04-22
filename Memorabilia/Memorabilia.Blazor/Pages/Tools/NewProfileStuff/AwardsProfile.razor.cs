namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public partial class AwardsProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private AwardProfileViewModel[] Awards = Array.Empty<AwardProfileViewModel>();

    protected override void OnParametersSet()
    {
        Awards = Person.Awards
                       .Filter(Sport)
                       .Select(award => new AwardProfileViewModel(award))
                       .OrderBy(award => award.Year)
                       .ThenBy(award => award.AwardTypeName)
                       .ToArray();
    }
}
