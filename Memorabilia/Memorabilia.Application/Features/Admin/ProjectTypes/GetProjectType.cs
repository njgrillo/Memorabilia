namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public record GetProjectType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetProjectType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.ProjectType> _projectTypeRepository;

        public Handler(IDomainRepository<Entity.ProjectType> projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetProjectType query)
            => await _projectTypeRepository.Get(query.Id);
    }
}
