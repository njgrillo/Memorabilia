namespace Memorabilia.Application.Features.Project;

public class GetProject
{
    public class Handler : QueryHandler<Query, ProjectViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public Handler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        protected override async Task<ProjectViewModel> Handle(Query query)
        {
            return new ProjectViewModel(await _projectRepository.Get(query.Id));
        }
    }

    public class Query : IQuery<ProjectViewModel>
    {
        public Query(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
