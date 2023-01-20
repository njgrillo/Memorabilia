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

    public int Id => _projectPerson.Id;

    public int? ItemTypeId => _projectPerson.ItemTypeId;

    public Person Person => _projectPerson.Person;

    public int? PriorityTypeId => _projectPerson.PriorityTypeId;

    public int? ProjectStatusTypeId => _projectPerson.ProjectStatusTypeId;

    public int? Rank => _projectPerson.Rank;

    public bool Upgrade => _projectPerson.Upgrade;
}
