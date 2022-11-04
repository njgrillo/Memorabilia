using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public record GetProjectTypes : IQuery<ProjectTypesViewModel>
{
    public class Handler : QueryHandler<GetProjectTypes, ProjectTypesViewModel>
    {
        private readonly IDomainRepository<ProjectType> _projectTypeRepository;

        public Handler(IDomainRepository<ProjectType> projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;
        }

        protected override async Task<ProjectTypesViewModel> Handle(GetProjectTypes query)
        {
            return new ProjectTypesViewModel(await _projectTypeRepository.GetAll());
        }
    }
}
