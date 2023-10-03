namespace Memorabilia.Application.Features.Admin.PriorityTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetPriorityType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetPriorityType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<Entity.PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetPriorityType query)
            => await _priorityTypeRepository.Get(query.Id);
    }
}
