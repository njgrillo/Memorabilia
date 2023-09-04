namespace Memorabilia.Application.Features.Admin.Conditions;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetCondition(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetCondition, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.Condition> _conditionRepository;

        public Handler(IDomainRepository<Entity.Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetCondition query)
            => await _conditionRepository.Get(query.Id);
    }
}
