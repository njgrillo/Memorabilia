namespace Memorabilia.Application.Features.Project;

public record GetProjects(int UserId) : IQuery<Domain.Entities.Project[]>
{
    public class Handler : QueryHandler<GetProjects, Domain.Entities.Project[]>
    {
        private readonly IProjectRepository _projectRepository;

        public Handler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        protected override async Task<Domain.Entities.Project[]> Handle(GetProjects query)
        {
            return (await _projectRepository.GetAll(query.UserId))
                       .OrderBy(project => project.Name)
                       .ToArray();
        }
    }
}
