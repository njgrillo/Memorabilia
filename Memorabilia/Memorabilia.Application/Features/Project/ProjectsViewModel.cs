using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Project
{
    public class ProjectsViewModel : ViewModel
    {
        public ProjectsViewModel() { }

        public ProjectsViewModel(IEnumerable<Domain.Entities.Project> projects)
        {
            Projects = projects.Select(project => new ProjectViewModel(project)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Home";

        public override string ItemTitle => "Project";

        public override string PageTitle => "Projects";

        public List<ProjectViewModel> Projects { get; set; } = new();

        public override string RoutePrefix => "Projects";
    }
}
