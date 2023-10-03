namespace Memorabilia.Application.Features.Admin.ItemTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetItemTypes() : IQuery<Entity.ItemType[]>
{
    public class Handler : QueryHandler<GetItemTypes, Entity.ItemType[]>
    {
        private readonly IDomainRepository<Entity.ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<Entity.ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task<Entity.ItemType[]> Handle(GetItemTypes query)
            => await _itemTypeRepository.GetAll();
    }
}
