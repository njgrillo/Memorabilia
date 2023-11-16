namespace Memorabilia.Application.Features.Admin.Conditions;

public record GetCondition(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.Condition> conditionRepository) 
        : QueryHandler<GetCondition, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetCondition query)
            => await conditionRepository.Get(query.Id);
    }
}
