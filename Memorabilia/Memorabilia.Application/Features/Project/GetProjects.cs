namespace Memorabilia.Application.Features.Project;

public record GetProjects(int UserId) : IQuery<ProjectsViewModel>
{
    public class Handler : QueryHandler<GetProjects, ProjectsViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public Handler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        protected override async Task<ProjectsViewModel> Handle(GetProjects query)
        {
            var projects = (await _projectRepository.GetAll(query.UserId)).OrderBy(project => project.Name);

            return new ProjectsViewModel(projects);
        }
    }
}
