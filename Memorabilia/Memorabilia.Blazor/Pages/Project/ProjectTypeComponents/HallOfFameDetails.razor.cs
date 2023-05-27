namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class HallOfFameDetails
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public SaveProjectViewModel Model { get; set; }

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

        SaveProjectPersonViewModel projectPerson
            = (SaveProjectPersonViewModel)result.Data;

        //TODO: Add - Don't Link - Then link from grid - See HelmetTypeDetails

        Model.People.Add(projectPerson);
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

        var dialog = DialogService.Show<ImportProjectPersonDialog>("Import Project People", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var persons = (Domain.Entities.Person[])result.Data;

        if (!persons.Any())
            return;

        var projectPersons = persons.Select(person => new PersonViewModel(person))
                                    .Select(personModel => new SavePersonViewModel(personModel))
                                    .Select(savePersonModel => new ProjectPersonViewModel(new Domain.Entities.ProjectPerson
                                    {
                                        ItemTypeId = Model.ItemTypeId,
                                        Person = persons.Single(person => person.Id == savePersonModel.Id),
                                        PersonId = savePersonModel.Id,
                                        Project = new Domain.Entities.Project(Model.Name, Model.StartDate, Model.EndDate, Model.UserId, Model.ProjectType.Id),
                                        ProjectId = Model.Id
                                    }))
                                    .Select(projectPerson => new SaveProjectPersonViewModel(projectPerson))
                                    .ToArray();

        Model.People.AddRange(projectPersons);
    }
}
