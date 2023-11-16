namespace Memorabilia.Application.Features.Project;

public record GetProjectQuery(int Id) : IQuery<Entity.Project>
{
    public class Handler(IProjectRepository projectRepository) 
        : QueryHandler<GetProjectQuery, Entity.Project>
    {
        protected override async Task<Entity.Project> Handle(GetProjectQuery query)
            => await projectRepository.Get(query.Id);
    }
}
