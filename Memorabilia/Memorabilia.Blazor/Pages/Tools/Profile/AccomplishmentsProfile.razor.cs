namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class AccomplishmentsProfile : PersonProfile
{
    [Parameter]
    public Sport Sport { get; set; }

    private AccomplishmentProfileModel[] Accomplishments 
        = [];

    private string _search;

    protected override void OnParametersSet()
    {
        Accomplishments = Person.Accomplishments
                                .Filter(Sport, OccupationType)
                                .Select(accomplishment => new AccomplishmentProfileModel(accomplishment))
                                .ToArray();
    }

    private bool FilterFunc1(AccomplishmentProfileModel model)
        => FilterFunc(model, _search);

    private static bool FilterFunc(AccomplishmentProfileModel model, string search)
        => search.IsNullOrEmpty() ||
           model.AccomplishmentTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.AccomplishmentTypeAbbreviation.Contains(search, StringComparison.OrdinalIgnoreCase);
}
