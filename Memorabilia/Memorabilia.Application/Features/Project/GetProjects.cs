using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Project;

public record GetProjects() : IQuery<Entity.Project[]>
{
    public class Handler(IProjectRepository projectRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetProjects, Entity.Project[]>
    {
        protected override async Task<Entity.Project[]> Handle(GetProjects query)
            => (await projectRepository.GetAll(applicationStateService.CurrentUser.Id))
                       .OrderBy(project => project.Name)
                       .ToArray();
    }
}
