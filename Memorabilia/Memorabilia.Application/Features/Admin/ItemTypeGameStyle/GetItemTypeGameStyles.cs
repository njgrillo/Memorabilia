namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public record GetItemTypeGameStyles(int? ItemTypeId = null) : IQuery<Entity.ItemTypeGameStyleType[]>
{
    public class Handler : QueryHandler<GetItemTypeGameStyles, Entity.ItemTypeGameStyleType[]>
    {
        private readonly IItemTypeGameStyleTypeRepository _itemTypeGameStyleRepository;

        public Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository)
        {
            _itemTypeGameStyleRepository = itemTypeGameStyleRepository;
        }

        protected override async Task<Entity.ItemTypeGameStyleType[]> Handle(GetItemTypeGameStyles query)
            => await _itemTypeGameStyleRepository.GetAll(query.ItemTypeId);
    }
}
