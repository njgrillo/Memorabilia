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

    protected ProjectsModel Model = new();

    protected async Task OnLoad()
    {
        Model = new ProjectsModel(await QueryRouter.Send(new GetProjects(UserId)));
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Project");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await Delete(id);
    }

    protected async Task Delete(int id)
    {
        var deletedItem = Model.Projects.Single(project => project.Id == id);
        var viewModel = new ProjectEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveProject.Command(viewModel));

        Model.Projects.Remove(deletedItem);

        Snackbar.Add($"{Model.ItemTitle} was deleted successfully!", Severity.Success);
    }
}
