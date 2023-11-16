namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public record GetItemTypeGameStyle(int Id) : IQuery<Entity.ItemTypeGameStyleType>
{
    public class Handler(IItemTypeGameStyleTypeRepository itemTypeGameStyleRepository) 
        : QueryHandler<GetItemTypeGameStyle, Entity.ItemTypeGameStyleType>
    {
        protected override async Task<Entity.ItemTypeGameStyleType> Handle(GetItemTypeGameStyle query)
            => await itemTypeGameStyleRepository.Get(query.Id);
    }
}
