using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public record GetProjectType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetProjectType, DomainViewModel>
    {
        private readonly IDomainRepository<ProjectType> _projectTypeRepository;

        public Handler(IDomainRepository<ProjectType> projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetProjectType query)
        {
            return new DomainViewModel(await _projectTypeRepository.Get(query.Id));
        }
    }
}
