namespace Memorabilia.Application.Features.Project;

public class ProjectsModel : Model
{
    public ProjectsModel() { }

    public ProjectsModel(IEnumerable<Entity.Project> projects)
    {
        Projects = projects.Select(project => new ProjectModel(project))
                           .ToList();
    }

    public List<ProjectModel> Projects { get; set; } 
        = new();
}
