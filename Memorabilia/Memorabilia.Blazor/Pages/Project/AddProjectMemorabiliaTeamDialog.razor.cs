﻿namespace Memorabilia.Blazor.Pages.Project;

public partial class AddProjectMemorabiliaTeamDialog
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int ItemTypeId { get; set; }

    [Parameter]
    public int MaxRank { get; set; }

    [Parameter]
    public int ProjectId { get; set; }

    protected ProjectEditModel Project;

    protected ProjectMemorabiliaTeamEditModel ProjectMemorabiliaTeam 
        = new();

    protected override async Task OnInitializedAsync()
    {
        if (ProjectId == 0)
            return;

        Project = new ProjectEditModel(new ProjectModel(await Mediator.Send(new GetProjectQuery(ProjectId))));
    }

    protected void Add()
    {
        if (ProjectMemorabiliaTeam.Team == null)
            return;

        ProjectMemorabiliaTeam.ItemTypeId = ItemTypeId;
        ProjectMemorabiliaTeam.Id = ProjectId;
        ProjectMemorabiliaTeam.UserId = ApplicationStateService.CurrentUser.Id;

        MudDialog.Close(DialogResult.Ok(ProjectMemorabiliaTeam));
    }

    private async Task AddMemorabiliaLink(ProjectMemorabiliaTeamEditModel projectMemorabiliaTeam)
    {
        var parameters = new Dictionary<string, object>
        {
            ["ItemTypeId"] = ItemTypeId,
            ["ProjectTypeId"] = projectMemorabiliaTeam.Project.ProjectTypeId,
            ["TeamId"] = projectMemorabiliaTeam.Team.Id
        };

        SetProjectDetailsParameters(parameters);

        var dialogParameters = new DialogParameters
        {
            ["Parameters"] = parameters,
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<SelectProjectMemorabiliaDialog>("Select Memorabilia", dialogParameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var results = (Dictionary<string, string>)result.Data;

        _ = results["MemorabiliaId"].TryParse(out int memorabiliaId);

        projectMemorabiliaTeam.MemorabiliaId = memorabiliaId;
        projectMemorabiliaTeam.MemorabiliaFileName = results["MemorabiliaFileName"];
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void SetProjectDetailsParameters(Dictionary<string, object> parameters)
    {
        var projectType = ProjectType.Find(Project.ProjectType.Id);

        switch (projectType.ToString())
        {
            case "HelmetType":
                parameters.Add("HelmetTypeId", Project.Helmet.HelmetTypeId);

                if (Project.Helmet.HelmetFinishId.HasValue)
                    parameters.Add("HelmetFinishId", Project.Helmet.HelmetFinishId);

                if (Project.Helmet.SizeId.HasValue)
                    parameters.Add("HelmetSizeId", Project.Helmet.SizeId);

                break;
            case "Team":
                if (Project.Team.Year.HasValue)
                    parameters.Add("TeamYear", Project.Team.Year);

                break;
            default:
                break;
        }
    }
}
