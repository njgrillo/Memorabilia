namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public record GetItemTypeSizes(int? ItemTypeId = null) : IQuery<Entity.ItemTypeSize[]>
{
    public class Handler(IItemTypeSizeRepository itemTypeSizeRepository) 
        : QueryHandler<GetItemTypeSizes, Entity.ItemTypeSize[]>
    {
        protected override async Task<Entity.ItemTypeSize[]> Handle(GetItemTypeSizes query)
            => await itemTypeSizeRepository.GetAll(query.ItemTypeId);
    }
}
