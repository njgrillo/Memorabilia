namespace Memorabilia.Application.Features.Project;

public record GetProjects(int UserId) : IQuery<Entity.Project[]>
{
    public class Handler : QueryHandler<GetProjects, Entity.Project[]>
    {
        private readonly IProjectRepository _projectRepository;

        public Handler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        protected override async Task<Entity.Project[]> Handle(GetProjects query)
            => (await _projectRepository.GetAll(query.UserId))
                       .OrderBy(project => project.Name)
                       .ToArray();
    }
}
