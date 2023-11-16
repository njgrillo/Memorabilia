namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public record GetProjectStatusType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.ProjectStatusType> projectStatusTypeRepository) 
        : QueryHandler<GetProjectStatusType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetProjectStatusType query)
            => await projectStatusTypeRepository.Get(query.Id);
    }
}
