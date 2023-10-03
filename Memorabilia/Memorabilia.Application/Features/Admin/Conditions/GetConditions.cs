namespace Memorabilia.Application.Features.Admin.Conditions;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetConditions() : IQuery<Entity.Condition[]>
{
    public class Handler : QueryHandler<GetConditions, Entity.Condition[]>
    {
        private readonly IDomainRepository<Entity.Condition> _conditionRepository;

        public Handler(IDomainRepository<Entity.Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task<Entity.Condition[]> Handle(GetConditions query)
            => await _conditionRepository.GetAll();
    }
}
