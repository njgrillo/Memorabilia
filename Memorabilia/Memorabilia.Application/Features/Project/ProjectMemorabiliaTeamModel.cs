using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Project;

public class ProjectMemorabiliaTeamModel
{
    private readonly ProjectMemorabiliaTeam _projectMemorabiliaTeam;

    public ProjectMemorabiliaTeamModel() { }

    public ProjectMemorabiliaTeamModel(ProjectMemorabiliaTeam projectMemorabiliaTeam)
    {
        _projectMemorabiliaTeam = projectMemorabiliaTeam;
    }    

    public int Id => _projectMemorabiliaTeam.Id;

    public int? ItemTypeId => _projectMemorabiliaTeam.ItemTypeId;

    public string MemorabiliaFileName
        => _projectMemorabiliaTeam.Memorabilia != null
        ? _projectMemorabiliaTeam.Memorabilia
                                 .Images
                                 .FirstOrDefault(image => image.ImageTypeId == Domain.Constants.ImageType.Primary.Id) ?.FileName ?? string.Empty
        : string.Empty;

    public int? MemorabiliaId => _projectMemorabiliaTeam.MemorabiliaId;    

    public int? PriorityTypeId => _projectMemorabiliaTeam.PriorityTypeId;

    public Domain.Entities.Project Project => _projectMemorabiliaTeam.Project;

    public int? ProjectStatusTypeId => _projectMemorabiliaTeam.ProjectStatusTypeId;

    public int ProjectTypeId => _projectMemorabiliaTeam.Project.ProjectTypeId;

    public int? Rank => _projectMemorabiliaTeam.Rank;

    public Team Team => _projectMemorabiliaTeam.Team;

    public bool Upgrade => _projectMemorabiliaTeam.Upgrade;

    public int UserId => _projectMemorabiliaTeam.Project.UserId;
}
