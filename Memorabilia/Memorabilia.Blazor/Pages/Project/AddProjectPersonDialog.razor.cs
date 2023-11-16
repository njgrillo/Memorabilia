﻿using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Project;

public partial class AddProjectPersonDialog
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

    protected ProjectPersonEditModel ProjectPerson 
        = new();

    protected override async Task OnInitializedAsync()
    {
        if (ProjectId == 0)
            return;

        Project = (await Mediator.Send(new GetProjectQuery(ProjectId))).ToEditModel();
    }

    protected void Add()
    {
        if (ProjectPerson.Person == null)
            return;

        ProjectPerson.ItemTypeId = ItemTypeId;
        ProjectPerson.Id = ProjectId;
        ProjectPerson.UserId = ApplicationStateService.CurrentUser.Id;

        MudDialog.Close(DialogResult.Ok(ProjectPerson));
    }

    private async Task AddAutographLink(ProjectPersonEditModel projectPerson)
    {
        var parameters = new Dictionary<string, object>
        {
            ["ItemTypeId"] = ItemTypeId,
            ["PersonId"] = projectPerson.Person.Id,
            ["ProjectTypeId"] = Project.ProjectType.Id
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

        var dialog = DialogService.Show<SelectProjectAutographDialog>("Select Autograph", dialogParameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var results = (Dictionary<string, string>)result.Data;

        _ = results["AutographId"].TryParse(out int autographId);

        projectPerson.AutographId = autographId;
        projectPerson.AutographFileName = results["AutographFileName"];
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
            case "BaseballType":
                parameters.Add("BaseballTypeId", Project.Baseball.BaseballTypeId);

                if (Project.Baseball.TeamId.HasValue)
                    parameters.Add("BaseballTypeTeamId", Project.Baseball.TeamId);

                if (Project.Baseball.Year.HasValue)
                    parameters.Add("BaseballTypeYear", Project.Baseball.Year);

                break;
            case "Card":
                parameters.Add("CardBrandId", Project.Card.BrandId);

                if (Project.Card.TeamId.HasValue)
                    parameters.Add("CardTeamId", Project.Card.TeamId);

                if (Project.Card.Year.HasValue)
                    parameters.Add("CardYear", Project.Card.Year);

                break;
            case "HallofFame":
                parameters.Add("HallOfFameSportLeagueLevelId", Project.HallOfFame.SportLeagueLevelId);

                if (Project.HallOfFame.ItemTypeId.HasValue)
                    parameters.Add("HallOfFameItemTypeId", Project.HallOfFame.ItemTypeId);

                if (Project.HallOfFame.Year.HasValue)
                    parameters.Add("HallOfFameYear", Project.HallOfFame.Year);

                break;
            case "ItemType":
                if (!parameters.ContainsKey("ItemTypeId"))
                    parameters.Add("ItemTypeId", Project.Item.ItemTypeId);

                parameters.Add("MultiSignedItem", Project.Item.MultiSignedItem);

                break;
            case "Team":
                parameters.Add("TeamId", Project.Team.TeamId);

                if (Project.Team.Year.HasValue)
                    parameters.Add("TeamYear", Project.Team.Year);

                break;
            case "WorldSeries":
                parameters.Add("WorldSeriesTeamId", Project.WorldSeries.TeamId);

                if (Project.WorldSeries.ItemTypeId.HasValue)
                    parameters.Add("WorldSeriesItemTypeId", Project.WorldSeries.ItemTypeId);

                if (Project.WorldSeries.Year.HasValue)
                    parameters.Add("WorldSeriesYear", Project.WorldSeries.Year);

                break;
            default:
                break;
        }
    }
}
