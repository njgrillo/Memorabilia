namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public record GetItemTypeSize(int Id) : IQuery<Entity.ItemTypeSize>
{
    public class Handler(IItemTypeSizeRepository itemTypeSizeRepository) 
        : QueryHandler<GetItemTypeSize, Entity.ItemTypeSize>
    {
        protected override async Task<Entity.ItemTypeSize> Handle(GetItemTypeSize query)
            => await itemTypeSizeRepository.Get(query.Id);
    }
}
