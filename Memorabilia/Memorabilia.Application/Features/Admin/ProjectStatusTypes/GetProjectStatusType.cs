using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public record GetProjectStatusType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetProjectStatusType, DomainViewModel>
    {
        private readonly IDomainRepository<ProjectStatusType> _projectStatusTypeRepository;

        public Handler(IDomainRepository<ProjectStatusType> projectStatusTypeRepository)
        {
            _projectStatusTypeRepository = projectStatusTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetProjectStatusType query)
        {
            return new DomainViewModel(await _projectStatusTypeRepository.Get(query.Id));
        }
    }
}
