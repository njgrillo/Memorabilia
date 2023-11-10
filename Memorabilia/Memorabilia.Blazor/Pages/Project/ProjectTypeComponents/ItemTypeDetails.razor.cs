namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class ItemTypeDetails
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public ProjectEditModel Model { get; set; }

    private bool _displayCompleted;

    private async Task AddProjectPerson()
    {
        var parameters = new DialogParameters
        {
            ["ItemTypeId"] = Model.Item.ItemTypeId,
            ["MaxRank"] = Model.People.Any() ? Model.People.Max(person => person.Rank) + 1 : 1,
            ["ProjectId"] = Model.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddProjectPersonDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        ProjectPersonEditModel projectPerson
            = (ProjectPersonEditModel)result.Data;

        //TODO: Add - Don't Link - Then link from grid - See HelmetTypeDetails

        Model.People.Add(projectPerson);

        await Mediator.Publish(new ProjectPersonAddedNotification(Model.Id, projectPerson.Person.Id, projectPerson.Rank));
    }
}
