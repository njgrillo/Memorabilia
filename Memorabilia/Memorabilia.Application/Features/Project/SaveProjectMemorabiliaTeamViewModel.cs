namespace Memorabilia.Application.Features.Project;

public class SaveProjectMemorabiliaTeamViewModel : SaveViewModel
{
    public SaveProjectMemorabiliaTeamViewModel() { }

    public SaveProjectMemorabiliaTeamViewModel(ProjectMemorabiliaTeamViewModel viewModel)
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

    public string DoubleDownIcon => MudBlazor.Icons.Material.Filled.KeyboardDoubleArrowDown;

    public string DoubleUpIcon => MudBlazor.Icons.Material.Filled.KeyboardDoubleArrowUp;

    public string DownIcon => MudBlazor.Icons.Material.Filled.ArrowDownward;

    public int ItemTypeId { get; set; }

    public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId)?.Name;

    public string MemorabiliaFileName { get; set; }

    public int MemorabiliaId { get; set; }    

    public int PriorityTypeId { get; set; }

    public string PriorityTypeName
        => Domain.Constants.PriorityType.Find(PriorityTypeId)?.Name;

    public Domain.Entities.Project Project { get; }

    public int ProjectStatusTypeId { get; set; } = Domain.Constants.ProjectStatusType.NotStarted.Id;

    public string ProjectStatusTypeName
        => Domain.Constants.ProjectStatusType.Find(ProjectStatusTypeId)?.Name
        ?? Domain.Constants.ProjectStatusType.NotStarted.Name;

    public int? Rank { get; set; }

    public Domain.Entities.Team Team { get; set; } = new();

    public string TemplateImageFileName { get; set; }

    public string UpIcon => MudBlazor.Icons.Material.Filled.ArrowUpward;

    public bool Upgrade { get; set; }

    public int UserId { get; set; }
}
