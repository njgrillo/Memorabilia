namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public record GetProjectType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.ProjectType> projectTypeRepository) 
        : QueryHandler<GetProjectType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetProjectType query)
            => await projectTypeRepository.Get(query.Id);
    }
}
