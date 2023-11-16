namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class HelmetTypeDetails
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public ProjectEditModel Model { get; set; }

    protected static int ItemTypeId 
        => ItemType.Helmet.Id;

    private bool _displayCompleted 
        = true;

    protected async Task AddProjectMemorabiliaTeam()
    {
        var parameters = new DialogParameters
        {
            ["ItemTypeId"] = ItemTypeId,
            ["MaxRank"] = Model.MemorabiliaTeams.Count != 0 ? Model.MemorabiliaTeams.Max(item => item.Rank) + 1 : 1, 
            ["ProjectId"] = Model.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddProjectMemorabiliaTeamDialog>(string.Empty, parameters, options); 
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        ProjectMemorabiliaTeamEditModel projectMemorabiliaTeam
            = (ProjectMemorabiliaTeamEditModel)result.Data;

        //TODO: Add - Don't Link - Then link from grid

        Model.MemorabiliaTeams.Add(projectMemorabiliaTeam);

        await Mediator.Publish(new ProjectMemorabiliaTeamAddedNotification(Model.Id, 
                                                                           projectMemorabiliaTeam.Team.Id, 
                                                                           projectMemorabiliaTeam.Rank));
    }

    protected async Task OnImport()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ImportProjectTeamDialog>(string.Empty, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var teams = (Entity.Team[])result.Data;

        if (teams.IsNullOrEmpty())
            return;

        var projectTeams = teams.Select(team => new ProjectMemorabiliaTeamModel(new Entity.ProjectMemorabiliaTeam
                                                {
                                                    ItemTypeId = ItemType.Helmet.Id,
                                                    Project = new Entity.Project(Model.Name, Model.StartDate, Model.EndDate, Model.UserId, Model.ProjectType.Id),
                                                    ProjectId = Model.Id,
                                                    Team = team,
                                                    TeamId = team.Id
                                                }))
                                .Select(projectPerson => new ProjectMemorabiliaTeamEditModel(projectPerson))
                                .ToArray();

        Model.MemorabiliaTeams.AddRange(projectTeams);
    }
}
