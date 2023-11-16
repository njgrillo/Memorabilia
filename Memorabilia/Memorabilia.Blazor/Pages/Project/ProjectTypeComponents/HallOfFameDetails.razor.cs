namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class HallOfFameDetails
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
            ["ItemTypeId"] = Model.ItemTypeId,
            ["MaxRank"] = Model.People.Count != 0 ? Model.People.Max(person => person.Rank) + 1 : 1,
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

    protected async Task OnImport()
    {
        var parameters = new DialogParameters
        {
            ["SportLeagueLevelId"] = Model.HallOfFame.SportLeagueLevelId,
            ["Year"] = Model.HallOfFame.Year.HasValue ? Model.HallOfFame.Year : null
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ImportProjectHallOfFameDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var persons = (Entity.Person[])result.Data;

        if (persons.IsNullOrEmpty())
            return;

        ProjectPersonEditModel[] projectPersons = persons.Select(person => new PersonModel(person))
                                                         .Select(personModel => new PersonEditModel(personModel))
                                                         .Select(savePersonModel => new ProjectPersonModel(new Entity.ProjectPerson
                                                         {
                                                            ItemTypeId = Model.HallOfFame.ItemTypeId ?? Model.ItemTypeId,
                                                            Person = persons.Single(person => person.Id == savePersonModel.Id),
                                                            PersonId = savePersonModel.Id,
                                                            Project = new Entity.Project(Model.Name, Model.StartDate, Model.EndDate, Model.UserId, Model.ProjectType.Id),
                                                            ProjectId = Model.Id
                                                         }))
                                                         .Select(projectPerson => new ProjectPersonEditModel(projectPerson))
                                                         .ToArray();

        Model.People.AddRange(projectPersons);
    }
}
