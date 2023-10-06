namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public record GetProjectStatusType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetProjectStatusType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.ProjectStatusType> _projectStatusTypeRepository;

        public Handler(IDomainRepository<Entity.ProjectStatusType> projectStatusTypeRepository)
        {
            _projectStatusTypeRepository = projectStatusTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetProjectStatusType query)
            => await _projectStatusTypeRepository.Get(query.Id);
    }
}
