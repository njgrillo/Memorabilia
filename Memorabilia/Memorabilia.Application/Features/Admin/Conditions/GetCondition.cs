namespace Memorabilia.Application.Features.Admin.Conditions;

public record GetCondition(int Id) : IQuery<Entity.Condition>
{
    public class Handler : QueryHandler<GetCondition, Entity.Condition>
    {
        private readonly IDomainRepository<Entity.Condition> _conditionRepository;

        public Handler(IDomainRepository<Entity.Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task<Entity.Condition> Handle(GetCondition query)
            => await _conditionRepository.Get(query.Id);
    }
}
