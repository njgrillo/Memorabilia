namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public record GetItemTypeBrands(int? ItemTypeId = null) : IQuery<Entity.ItemTypeBrand[]>
{
    public class Handler(IItemTypeBrandRepository itemTypeBrandRepository) 
        : QueryHandler<GetItemTypeBrands, Entity.ItemTypeBrand[]>
    {
        protected override async Task<Entity.ItemTypeBrand[]> Handle(GetItemTypeBrands query)
            => await itemTypeBrandRepository.GetAll(query.ItemTypeId);
    }
}
