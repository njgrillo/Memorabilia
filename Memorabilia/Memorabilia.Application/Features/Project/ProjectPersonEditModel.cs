﻿namespace Memorabilia.Application.Features.Project;

public class ProjectPersonEditModel : EditModel
{
    public ProjectPersonEditModel() { }

    public ProjectPersonEditModel(ProjectPersonModel viewModel)
    {            
        Id = viewModel.Id;
        ItemTypeId = viewModel.ItemTypeId ?? 0;
        Rank = viewModel.Rank;
        Upgrade = viewModel.Upgrade;
        PriorityTypeId = viewModel.PriorityTypeId ?? 0;
        ProjectStatusTypeId = viewModel.ProjectStatusTypeId ?? 0;
        Person =  new SavePersonViewModel(new PersonViewModel(viewModel.Person));
        MemorabiliaId = viewModel.MemorabiliaId ?? 0;
        AutographId = viewModel.AutographId ?? 0;
        UserId = viewModel.UserId;
        AutographFileName = viewModel.AutographFileName;
        Project = viewModel.Project;
    }

    public int AutographId { get; set; }

    public string AutographFileName { get; set; }

    public bool Deceased => Person?.DeathDate.HasValue ?? false;

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

    public int MemorabiliaId { get; set; }

    [Required]
    public SavePersonViewModel Person { get; set; } = new();              

    public int PriorityTypeId { get; set; }

    public string PriorityTypeName 
        => Constant.PriorityType.Find(PriorityTypeId)?.Name;

    public Entity.Project Project { get; set; } 

    public int ProjectStatusTypeId { get; set; } 
        = Constant.ProjectStatusType.NotStarted.Id;

    public string ProjectStatusTypeName 
        => Constant.ProjectStatusType.Find(ProjectStatusTypeId)?.Name 
        ?? Constant.ProjectStatusType.NotStarted.Name;

    public int? Rank { get; set; }

    public string UpIcon 
        => MudBlazor.Icons.Material.Filled.ArrowUpward;

    public bool Upgrade { get; set; }

    public int UserId { get; set; }
}
