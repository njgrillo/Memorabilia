namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public record GetPriorityTypes() : IQuery<Entity.PriorityType[]>
{
    public class Handler(IDomainRepository<Entity.PriorityType> priorityTypeRepository) 
        : QueryHandler<GetPriorityTypes, Entity.PriorityType[]>
    {
        protected override async Task<Entity.PriorityType[]> Handle(GetPriorityTypes query)
            => await priorityTypeRepository.GetAll();
    }
}
