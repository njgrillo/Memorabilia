﻿namespace Memorabilia.Blazor.Pages.Project;

public partial class ViewProjects
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected ProjectsModel Model 
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = new ProjectsModel(await Mediator.Send(new GetProjects()));
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
        ProjectModel deletedItem = Model.Projects.Single(project => project.Id == id);

        var editModel = new ProjectEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveProject.Command(editModel));

        Model.Projects.Remove(deletedItem);

        Snackbar.Add($"Project was deleted successfully!", Severity.Success);
    }
}
