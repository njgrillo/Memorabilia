#nullable disable

namespace Memorabilia.Blazor.Pages.Project;

public partial class ViewProjects : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private ProjectsViewModel _viewModel = new();

    protected async Task OnLoad()
    {
        _viewModel = await QueryRouter.Send(new GetProjects.Query(UserId)).ConfigureAwait(false);
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Project");
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        await Delete(id).ConfigureAwait(false);
    }

    protected async Task Delete(int id)
    {
        var deletedItem = _viewModel.Projects.Single(project => project.Id == id);
        var viewModel = new SaveProjectViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveProject.Command(viewModel)).ConfigureAwait(false);

        _viewModel.Projects.Remove(deletedItem);

        Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
    }
}
