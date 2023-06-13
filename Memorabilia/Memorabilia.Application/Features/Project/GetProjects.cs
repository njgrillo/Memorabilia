namespace Memorabilia.Application.Features.Project;

public record GetProjects() : IQuery<Entity.Project[]>
{
    public class Handler : QueryHandler<GetProjects, Entity.Project[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IProjectRepository _projectRepository;

        public Handler(IProjectRepository projectRepository, 
                       IApplicationStateService applicationStateService)
        {
            _projectRepository = projectRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Project[]> Handle(GetProjects query)
            => (await _projectRepository.GetAll(_applicationStateService.CurrentUser.Id))
                       .OrderBy(project => project.Name)
                       .ToArray();
    }
}
