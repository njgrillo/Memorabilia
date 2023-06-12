namespace Memorabilia.Application.Features.Project;

public record GetProjectQuery(int Id) : IQuery<Entity.Project>
{
    public class Handler : QueryHandler<GetProjectQuery, Entity.Project>
    {
        private readonly IProjectRepository _projectRepository;

        public Handler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        protected override async Task<Entity.Project> Handle(GetProjectQuery query)
            => await _projectRepository.Get(query.Id);
    }
}
