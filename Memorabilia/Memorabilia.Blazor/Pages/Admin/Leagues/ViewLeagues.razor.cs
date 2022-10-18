#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Leagues;

public partial class ViewLeagues : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    private string Search;
    private LeaguesViewModel ViewModel = new();

    private bool FilterFunc1(LeagueViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetLeagues());
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete League");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    private async Task Delete(int id)
    {
        var deletedItem = ViewModel.Leagues.Single(League => League.Id == id);
        var viewModel = new SaveLeagueViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveLeague(viewModel));

        ViewModel.Leagues.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(LeagueViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!viewModel.Abbreviation.IsNullOrEmpty() &&
                viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
