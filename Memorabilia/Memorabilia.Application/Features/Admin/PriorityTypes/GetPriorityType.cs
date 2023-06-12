namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public record GetPriorityType(int Id) : IQuery<Entity.PriorityType>
{
    public class Handler : QueryHandler<GetPriorityType, Entity.PriorityType>
    {
        private readonly IDomainRepository<Entity.PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<Entity.PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task<Entity.PriorityType> Handle(GetPriorityType query)
            => await _priorityTypeRepository.Get(query.Id);
    }
}
