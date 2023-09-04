namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetItemTypeGameStyle(int Id) : IQuery<Entity.ItemTypeGameStyleType>
{
    public class Handler : QueryHandler<GetItemTypeGameStyle, Entity.ItemTypeGameStyleType>
    {
        private readonly IItemTypeGameStyleTypeRepository _itemTypeGameStyleRepository;

        public Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository)
        {
            _itemTypeGameStyleRepository = itemTypeGameStyleRepository;
        }

        protected override async Task<Entity.ItemTypeGameStyleType> Handle(GetItemTypeGameStyle query)
            => await _itemTypeGameStyleRepository.Get(query.Id);
    }
}
