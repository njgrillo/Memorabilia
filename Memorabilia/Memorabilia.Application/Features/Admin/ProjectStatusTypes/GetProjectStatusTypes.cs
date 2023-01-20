using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public record GetProjectStatusTypes() : IQuery<ProjectStatusTypesViewModel>
{
    public class Handler : QueryHandler<GetProjectStatusTypes, ProjectStatusTypesViewModel>
    {
        private readonly IDomainRepository<ProjectStatusType> _projectStatusTypeRepository;

        public Handler(IDomainRepository<ProjectStatusType> projectStatusTypeRepository)
        {
            _projectStatusTypeRepository = projectStatusTypeRepository;
        }

        protected override async Task<ProjectStatusTypesViewModel> Handle(GetProjectStatusTypes query)
        {
            return new ProjectStatusTypesViewModel(await _projectStatusTypeRepository.GetAll());
        }
    }
}
