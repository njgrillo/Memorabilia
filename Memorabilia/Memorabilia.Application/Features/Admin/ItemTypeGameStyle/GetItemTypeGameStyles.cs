namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public record GetItemTypeGameStyles(int? ItemTypeId = null) : IQuery<Entity.ItemTypeGameStyleType[]>
{
    public class Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository) 
        : QueryHandler<GetItemTypeGameStyles, Entity.ItemTypeGameStyleType[]>
    {
        protected override async Task<Entity.ItemTypeGameStyleType[]> Handle(GetItemTypeGameStyles query)
            => await itemTypeGameStyleRepository.GetAll(query.ItemTypeId);
    }
}
