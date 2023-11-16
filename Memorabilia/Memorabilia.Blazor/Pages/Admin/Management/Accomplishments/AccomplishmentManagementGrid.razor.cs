namespace Memorabilia.Blazor.Pages.Admin.Management.Accomplishments;

public partial class AccomplishmentManagementGrid
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public AccomplishmentManagementModel[] Accomplishments { get; set; }
        = [];

    private string _search;

    private bool Filter(AccomplishmentManagementModel model)
        => _search.IsNullOrEmpty() ||
           model.AccomplishmentType.Name.Contains(_search, StringComparison.OrdinalIgnoreCase) ||
           (!model.AccomplishmentType.Abbreviation.IsNullOrEmpty() &&
            model.AccomplishmentType.Abbreviation.Contains(_search, StringComparison.OrdinalIgnoreCase));
}
