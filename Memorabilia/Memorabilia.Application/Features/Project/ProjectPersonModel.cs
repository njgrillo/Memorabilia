namespace Memorabilia.Application.Features.Project;

public class ProjectPersonModel
{
    private readonly Entity.ProjectPerson _projectPerson;

    public ProjectPersonModel() { }

    public ProjectPersonModel(Entity.ProjectPerson projectPerson)
    {
        _projectPerson = projectPerson;
    }

    public int? AutographId 
        => _projectPerson.AutographId;

    public string AutographFileName
        => _projectPerson.Autograph != null
        ? _projectPerson.Autograph
                        .Images
                        .FirstOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?.FileName ?? string.Empty
        : string.Empty;

    public int Id 
        => _projectPerson.Id;

    public int? ItemTypeId 
        => _projectPerson.ItemTypeId;

    public int? MemorabiliaId 
        => _projectPerson.MemorabiliaId;

    public Entity.Person Person 
        => _projectPerson.Person;

    public int? PriorityTypeId 
        => _projectPerson.PriorityTypeId;

    public Entity.Project Project 
        => _projectPerson.Project;

    public int? ProjectStatusTypeId 
        => _projectPerson.ProjectStatusTypeId;

    public int ProjectTypeId 
        => _projectPerson.Project.ProjectTypeId;

    public int? Rank 
        => _projectPerson.Rank;

    public bool Upgrade 
        => _projectPerson.Upgrade;

    public int UserId 
        => _projectPerson.Project.UserId;
}
