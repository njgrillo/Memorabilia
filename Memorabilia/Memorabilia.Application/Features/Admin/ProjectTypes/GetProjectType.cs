using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public record GetProjectType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetProjectType, DomainModel>
    {
        private readonly IDomainRepository<ProjectType> _projectTypeRepository;

        public Handler(IDomainRepository<ProjectType> projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetProjectType query)
        {
            return new DomainModel(await _projectTypeRepository.Get(query.Id));
        }
    }
}
