namespace Memorabilia.Application.Features.Project;

public record GetProjectQuery(int Id) : IQuery<ProjectViewModel>
{
    public class Handler : QueryHandler<GetProjectQuery, ProjectViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public Handler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        protected override async Task<ProjectViewModel> Handle(GetProjectQuery query)
        {
            return new ProjectViewModel(await _projectRepository.Get(query.Id));
        }
    }
}
