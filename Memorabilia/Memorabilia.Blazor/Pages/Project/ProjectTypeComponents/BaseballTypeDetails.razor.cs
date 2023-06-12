namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class BaseballTypeDetails
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public ProjectEditModel Model { get; set; }

    protected BaseballType BaseballType
        => BaseballType.Find(Model.Baseball.BaseballTypeId);

    protected bool CanImport
        => Model.ProjectType == ProjectType.BaseballType
        && ((BaseballType?.CanImportByYear() ?? false)
            || (BaseballType?.CanImportByYearRange() ?? false));

    protected static int ItemTypeId => ItemType.Baseball.Id;

    private bool _displayCompleted;

    private async Task AddProjectPerson()
    {
        var parameters = new DialogParameters
        {
            ["ItemTypeId"] = Model.ItemTypeId,
            ["MaxRank"] = Model.People.Any() ? Model.People.Max(person => person.Rank) + 1 : 1,
            ["ProjectId"] = Model.Id,
            ["UserId"] = Model.UserId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddProjectPersonDialog>("Add Project Person", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        ProjectPersonEditModel projectPerson
            = (ProjectPersonEditModel)result.Data;

        //TODO: Add - Don't Link - Then link from grid - See HelmetTypeDetails
        //projectPerson.ProjectType = Model.ProjectType.Id;

        Model.People.Add(projectPerson);
    }

    protected async Task OnImport()
    {
        var parameters = new DialogParameters
        {
            ["BaseballTypeId"] = Model.Baseball.BaseballTypeId,
            ["Year"] = Model.Baseball.Year.HasValue ? Model.Baseball.Year : null
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ImportProjectPersonDialog>("Import Project People", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var persons = (Entity.Person[])result.Data;

        if (!persons.Any())
            return;

        var projectPersons = persons.Select(person => new PersonModel(person))
                                    .Select(personModel => new PersonEditModel(personModel))
                                    .Select(savePersonModel => new ProjectPersonModel(new Entity.ProjectPerson
                                    {
                                        ItemTypeId = ItemType.Baseball.Id,
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
