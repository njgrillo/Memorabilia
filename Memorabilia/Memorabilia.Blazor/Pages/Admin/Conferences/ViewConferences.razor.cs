#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Conferences;

public partial class ViewConferences
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
    private ConferencesViewModel ViewModel = new();

    private bool FilterFunc1(ConferenceViewModel viewModel) => FilterFunc(viewModel, Search);

    protected async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetConferences());
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Conference");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id);
    }

    private async Task Delete(int id)
    {
        var deletedItem = ViewModel.Conferences.Single(conference => conference.Id == id);
        var viewModel = new SaveConferenceViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveConference(viewModel));

        ViewModel.Conferences.Remove(deletedItem);

        Snackbar.Add($"{ViewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }

    private static bool FilterFunc(ConferenceViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!viewModel.Abbreviation.IsNullOrEmpty() &&
                viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
