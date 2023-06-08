namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class AccomplishmentsProfile : PersonProfile
{
    [Parameter]
    public Sport Sport { get; set; }

    private AccomplishmentProfileModel[] Accomplishments = Array.Empty<AccomplishmentProfileModel>();
    private string _search;

    protected override void OnParametersSet()
    {
        Accomplishments = Person.Accomplishments
                                .Filter(Sport, OccupationType)
                                .Select(accomplishment => new AccomplishmentProfileModel(accomplishment))
                                .ToArray();
    }

    private bool FilterFunc1(AccomplishmentProfileModel viewModel)
        => FilterFunc(viewModel, _search);

    private static bool FilterFunc(AccomplishmentProfileModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.AccomplishmentTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.AccomplishmentTypeAbbreviation.Contains(search, StringComparison.OrdinalIgnoreCase);
}
