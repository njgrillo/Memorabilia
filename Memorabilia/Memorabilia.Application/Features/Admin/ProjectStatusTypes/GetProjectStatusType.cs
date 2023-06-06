using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public record GetProjectStatusType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetProjectStatusType, DomainModel>
    {
        private readonly IDomainRepository<ProjectStatusType> _projectStatusTypeRepository;

        public Handler(IDomainRepository<ProjectStatusType> projectStatusTypeRepository)
        {
            _projectStatusTypeRepository = projectStatusTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetProjectStatusType query)
        {
            return new DomainModel(await _projectStatusTypeRepository.Get(query.Id));
        }
    }
}
