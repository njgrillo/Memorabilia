namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public record GetPriorityType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.PriorityType> priorityTypeRepository) 
        : QueryHandler<GetPriorityType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetPriorityType query)
            => await priorityTypeRepository.Get(query.Id);
    }
}
