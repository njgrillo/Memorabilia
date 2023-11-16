namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public record GetItemTypeLevels(int? ItemTypeId = null) : IQuery<Entity.ItemTypeLevel[]>
{
    public class Handler(IItemTypeLevelRepository itemTypeLevelRepository) 
        : QueryHandler<GetItemTypeLevels, Entity.ItemTypeLevel[]>
    {
        protected override async Task<Entity.ItemTypeLevel[]> Handle(GetItemTypeLevels query)
            => await itemTypeLevelRepository.GetAll(query.ItemTypeId);
    }
}
