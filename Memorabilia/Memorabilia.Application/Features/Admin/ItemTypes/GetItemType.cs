namespace Memorabilia.Application.Features.Admin.ItemTypes;

public record GetItemType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.ItemType> itemTypeRepository) 
        : QueryHandler<GetItemType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetItemType query)
            => await itemTypeRepository.Get(query.Id);
    }
}
