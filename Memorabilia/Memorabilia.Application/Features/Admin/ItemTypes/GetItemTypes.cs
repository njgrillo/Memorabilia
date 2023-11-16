namespace Memorabilia.Application.Features.Admin.ItemTypes;

public record GetItemTypes() : IQuery<Entity.ItemType[]>
{
    public class Handler(IDomainRepository<Entity.ItemType> itemTypeRepository) 
        : QueryHandler<GetItemTypes, Entity.ItemType[]>
    {
        protected override async Task<Entity.ItemType[]> Handle(GetItemTypes query)
            => await itemTypeRepository.GetAll();
    }
}
