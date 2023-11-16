namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public record GetItemTypeLevel(int Id) : IQuery<Entity.ItemTypeLevel>
{
    public class Handler(IItemTypeLevelRepository itemTypeLevelRepository) 
        : QueryHandler<GetItemTypeLevel, Entity.ItemTypeLevel>
    {
        protected override async Task<Entity.ItemTypeLevel> Handle(GetItemTypeLevel query)
            => await itemTypeLevelRepository.Get(query.Id);
    }
}
