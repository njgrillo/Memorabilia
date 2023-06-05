namespace Memorabilia.Application.Features.Project;

public record GetProjectQuery(int Id) : IQuery<Domain.Entities.Project>
{
    public class Handler : QueryHandler<GetProjectQuery, Domain.Entities.Project>
    {
        private readonly IProjectRepository _projectRepository;

        public Handler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        protected override async Task<Domain.Entities.Project> Handle(GetProjectQuery query)
        {
            return await _projectRepository.Get(query.Id);
        }
    }
}
