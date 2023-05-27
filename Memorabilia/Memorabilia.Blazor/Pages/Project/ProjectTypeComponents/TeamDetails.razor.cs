namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class TeamDetails
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public SaveProjectViewModel Model { get; set; }

    private bool _displayCompleted = true;

    protected async Task AddProjectMemorabiliaTeam()
    {
        var parameters = new DialogParameters
        {
            ["ItemTypeId"] = Model.ItemTypeId,
            ["MaxRank"] = Model.MemorabiliaTeams.Any() ? Model.MemorabiliaTeams.Max(item => item.Rank) + 1 : 1,
            ["ProjectId"] = Model.Id,
            ["UserId"] = Model.UserId
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

        SaveProjectMemorabiliaTeamViewModel projectMemorabiliaTeam
            = (SaveProjectMemorabiliaTeamViewModel)result.Data;

        //TODO: Add - Don't Link - Then link from grid

        Model.MemorabiliaTeams.Add(projectMemorabiliaTeam);
    }

    protected async Task OnImport()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ImportProjectTeamDialog>("Import Project Team", options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var teams = (Domain.Entities.Team[])result.Data;

        if (!teams.Any())
            return;

        var projectTeams = teams.Select(team => new ProjectMemorabiliaTeamViewModel(new Domain.Entities.ProjectMemorabiliaTeam
                                {
                                    ItemTypeId = Model.ItemTypeId,
                                    Project = new Domain.Entities.Project(Model.Name, Model.StartDate, Model.EndDate, Model.UserId, Model.ProjectType.Id),
                                    ProjectId = Model.Id,
                                    Team = team,
                                    TeamId = team.Id
                                }))
                                .Select(projectPerson => new SaveProjectMemorabiliaTeamViewModel(projectPerson))
                                .ToArray();

        Model.MemorabiliaTeams.AddRange(projectTeams);
    }
}
