namespace Memorabilia.Blazor.Pages.Admin.Management.AllStars;

public partial class AllStarManagementGrid
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public AllStarManagementModel[] AllStars { get; set; }
        = [];

    private string _search;

    private bool Filter(AllStarManagementModel model)
        => _search.IsNullOrEmpty() ||
           model.SportLeagueLevel.Name.Contains(_search, StringComparison.OrdinalIgnoreCase) ||
           model.SportLeagueLevel.SportName.Contains(_search, StringComparison.OrdinalIgnoreCase);
}
