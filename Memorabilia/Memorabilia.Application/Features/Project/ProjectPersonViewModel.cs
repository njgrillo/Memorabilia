using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Project;

public class ProjectPersonViewModel
{
    private readonly ProjectPerson _projectPerson;

    public ProjectPersonViewModel() { }

    public ProjectPersonViewModel(ProjectPerson projectPerson)
    {
        _projectPerson = projectPerson;
    }

    public int? AutographId => _projectPerson.AutographId;

    public string AutographFileName
        => _projectPerson.Autograph != null
        ? _projectPerson.Autograph
                        .Images
                        .FirstOrDefault(image => image.ImageTypeId == Domain.Constants.ImageType.Primary.Id)?.FileName ?? string.Empty
        : string.Empty;

    public int Id => _projectPerson.Id;

    public int? ItemTypeId => _projectPerson.ItemTypeId;

    public int? MemorabiliaId => _projectPerson.MemorabiliaId;

    public Person Person => _projectPerson.Person;

    public int? PriorityTypeId => _projectPerson.PriorityTypeId;

    public Domain.Entities.Project Project => _projectPerson.Project;

    public int? ProjectStatusTypeId => _projectPerson.ProjectStatusTypeId;

    public int ProjectTypeId => _projectPerson.Project.ProjectTypeId;

    public int? Rank => _projectPerson.Rank;

    public bool Upgrade => _projectPerson.Upgrade;

    public int UserId => _projectPerson.Project.UserId;
}
