using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Project
{
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
                return new ProjectsViewModel(await _projectRepository.GetAll(query.UserId).ConfigureAwait(false));
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
}
