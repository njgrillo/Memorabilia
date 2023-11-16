namespace Memorabilia.Application.Features.Admin.Conditions;

public record GetConditions() : IQuery<Entity.Condition[]>
{
    public class Handler(IDomainRepository<Entity.Condition> conditionRepository) 
        : QueryHandler<GetConditions, Entity.Condition[]>
    {
        protected override async Task<Entity.Condition[]> Handle(GetConditions query)
            => await conditionRepository.GetAll();
    }
}
