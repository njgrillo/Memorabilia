namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class AccomplishmentsProfile : PersonProfile
{
    [Parameter]
    public Sport Sport { get; set; }

    private AccomplishmentProfileViewModel[] Accomplishments = Array.Empty<AccomplishmentProfileViewModel>();
    private string _search;

    protected override void OnParametersSet()
    {
        Accomplishments = Person.Accomplishments
                                .Filter(Sport, OccupationType)
                                .Select(accomplishment => new AccomplishmentProfileViewModel(accomplishment))
                                .ToArray();
    }

    private bool FilterFunc1(AccomplishmentProfileViewModel viewModel)
        => FilterFunc(viewModel, _search);

    private static bool FilterFunc(AccomplishmentProfileViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.AccomplishmentTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.AccomplishmentTypeAbbreviation.Contains(search, StringComparison.OrdinalIgnoreCase);
    }    
}
