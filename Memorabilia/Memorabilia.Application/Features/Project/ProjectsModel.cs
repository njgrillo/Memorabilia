using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Project;

public class ProjectsModel : ViewModel
{
    public ProjectsModel() { }

    public ProjectsModel(IEnumerable<Domain.Entities.Project> projects)
    {
        Projects = projects.Select(project => new ProjectModel(project)).ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public override string ExitNavigationPath => "Home";

    public override string ItemTitle => "Project";

    public override string PageTitle => "Projects";

    public List<ProjectModel> Projects { get; set; } = new();

    public override string RoutePrefix => "Projects";
}
