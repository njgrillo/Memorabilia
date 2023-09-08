namespace Memorabilia.Application.Features.Project;

public class ProjectsModel : Model
{
    public ProjectsModel() { }

    public ProjectsModel(IEnumerable<Entity.Project> projects)
    {
        Projects = projects.Select(project => new ProjectModel(project))
                           .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public override string ExitNavigationPath 
        => "Home";

    public override string ItemTitle 
        => "Project";

    public override string PageTitle 
        => "Projects";

    public List<ProjectModel> Projects { get; set; } 
        = new();

    public override string RoutePrefix 
        => "MyStuff/Projects";
}
