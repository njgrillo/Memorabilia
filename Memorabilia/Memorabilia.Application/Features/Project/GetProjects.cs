namespace Memorabilia.Application.Features.Project;

public class GetProjects
{
    public class Handler : QueryHandler<Query, ProjectsViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public Handler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        protected override async Task<ProjectsViewModel> Handle(Query query)
        {
            var projects = (await _projectRepository.GetAll(query.UserId)).OrderBy(project => project.Name);

            return new ProjectsViewModel(projects);
        }
    }

    public class Query : IQuery<ProjectsViewModel>
    {
        public Query(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
