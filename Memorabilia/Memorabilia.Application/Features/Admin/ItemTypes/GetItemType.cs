namespace Memorabilia.Application.Features.Admin.ItemTypes;

public record GetItemType(int Id) : IQuery<Entity.ItemType>
{
    public class Handler : QueryHandler<GetItemType, Entity.ItemType>
    {
        private readonly IDomainRepository<Entity.ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<Entity.ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task<Entity.ItemType> Handle(GetItemType query)
            => await _itemTypeRepository.Get(query.Id);
    }
}
