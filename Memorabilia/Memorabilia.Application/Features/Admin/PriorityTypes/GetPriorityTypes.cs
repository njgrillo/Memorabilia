namespace Memorabilia.Application.Features.Admin.PriorityTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetPriorityTypes() : IQuery<Entity.PriorityType[]>
{
    public class Handler : QueryHandler<GetPriorityTypes, Entity.PriorityType[]>
    {
        private readonly IDomainRepository<Entity.PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<Entity.PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task<Entity.PriorityType[]> Handle(GetPriorityTypes query)
            => await _priorityTypeRepository.GetAll();
    }
}
