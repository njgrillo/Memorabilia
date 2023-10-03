namespace Memorabilia.Application.Features.Admin.ItemTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetItemType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetItemType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<Entity.ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetItemType query)
            => await _itemTypeRepository.Get(query.Id);
    }
}
