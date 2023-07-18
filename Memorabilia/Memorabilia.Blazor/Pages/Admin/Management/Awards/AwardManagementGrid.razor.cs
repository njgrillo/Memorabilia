namespace Memorabilia.Blazor.Pages.Admin.Management.Awards;

public partial class AwardManagementGrid
{  
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public AwardManagementModel[] Awards { get; set; }
        = Array.Empty<AwardManagementModel>();

    private string _search;

    private bool Filter(AwardManagementModel model)
        => _search.IsNullOrEmpty() ||
           model.AwardType.Name.Contains(_search, StringComparison.OrdinalIgnoreCase) ||
           (!model.AwardType.Abbreviation.IsNullOrEmpty() &&
            model.AwardType.Abbreviation.Contains(_search, StringComparison.OrdinalIgnoreCase));
}
