﻿namespace Memorabilia.Application.Features.Project;

public class ProjectMemorabiliaTeamEditModel : EditModel
{
    public ProjectMemorabiliaTeamEditModel() { }

    public ProjectMemorabiliaTeamEditModel(ProjectMemorabiliaTeamModel viewModel)
    {
        Id = viewModel.Id;
        ItemTypeId = viewModel.ItemTypeId ?? 0;
        Rank = viewModel.Rank;
        Upgrade = viewModel.Upgrade;
        PriorityTypeId = viewModel.PriorityTypeId ?? 0;
        ProjectStatusTypeId = viewModel.ProjectStatusTypeId ?? 0;
        Team = viewModel.Team;
        MemorabiliaId = viewModel.MemorabiliaId ?? 0;
        UserId = viewModel.UserId;
        MemorabiliaFileName = viewModel.MemorabiliaFileName;
        Project = viewModel.Project;
    }

    public bool DisplayDoubleUpIcon => Rank > 1;

    public bool DisplayUpIcon => Rank > 1;

    public string DoubleDownIcon 
        => MudBlazor.Icons.Material.Filled.KeyboardDoubleArrowDown;

    public string DoubleUpIcon 
        => MudBlazor.Icons.Material.Filled.KeyboardDoubleArrowUp;

    public string DownIcon 
        => MudBlazor.Icons.Material.Filled.ArrowDownward;

    public int ItemTypeId { get; set; }

    public string ItemTypeName 
        => Constant.ItemType.Find(ItemTypeId)?.Name;

    public string MemorabiliaFileName { get; set; }

    public int MemorabiliaId { get; set; }    

    public int PriorityTypeId { get; set; }

    public string PriorityTypeName
        => Constant.PriorityType.Find(PriorityTypeId)?.Name;

    public Entity.Project Project { get; }

    public int ProjectStatusTypeId { get; set; }
        = Constant.ProjectStatusType.NotStarted.Id;

    public string ProjectStatusTypeName
        => Constant.ProjectStatusType.Find(ProjectStatusTypeId)?.Name
        ?? Constant.ProjectStatusType.NotStarted.Name;

    public int? Rank { get; set; }

    public Entity.Team Team { get; set; } = new();

    public string TemplateImageFileName { get; set; }

    public string UpIcon 
        => MudBlazor.Icons.Material.Filled.ArrowUpward;

    public bool Upgrade { get; set; }

    public int UserId { get; set; }
}
