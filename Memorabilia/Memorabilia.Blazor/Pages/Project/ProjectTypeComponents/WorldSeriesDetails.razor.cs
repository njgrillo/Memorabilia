﻿namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class WorldSeriesDetails
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public ProjectEditModel Model { get; set; }

    private bool _displayCompleted 
        = true;

    protected async Task AddProjectMemorabiliaTeam()
    {
        var parameters = new DialogParameters
        {
            ["ItemTypeId"] = Model.Item,
            ["MaxRank"] = Model.MemorabiliaTeams.Any() ? Model.MemorabiliaTeams.Max(item => item.Rank) + 1 : 1,
            ["ProjectId"] = Model.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddProjectMemorabiliaTeamDialog>("Add Project Memorabilia Team", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        ProjectMemorabiliaTeamEditModel projectMemorabiliaTeam
            = (ProjectMemorabiliaTeamEditModel)result.Data;

        //TODO: Add - Don't Link - Then link from grid

        Model.MemorabiliaTeams.Add(projectMemorabiliaTeam);
    }

    protected async Task OnImport()
    {
        var parameters = new DialogParameters
        {
            ["TeamId"] = Model.WorldSeries.TeamId,
            ["Year"] = Model.WorldSeries.Year.HasValue ? Model.WorldSeries.Year : null
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ImportProjectPersonTeamDialog>("Import World Series Roster", parameters, options);
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
                                        ItemTypeId = Model.WorldSeries.ItemTypeId ?? Model.ItemTypeId,
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
