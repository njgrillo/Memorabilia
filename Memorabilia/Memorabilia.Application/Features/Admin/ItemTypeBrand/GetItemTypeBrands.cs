namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetItemTypeBrands(int? ItemTypeId = null) : IQuery<Entity.ItemTypeBrand[]>
{
    public class Handler : QueryHandler<GetItemTypeBrands, Entity.ItemTypeBrand[]>
    {
        private readonly IItemTypeBrandRepository _itemTypeBrandRepository;

        public Handler(IItemTypeBrandRepository itemTypeBrandRepository)
        {
            _itemTypeBrandRepository = itemTypeBrandRepository;
        }

        protected override async Task<Entity.ItemTypeBrand[]> Handle(GetItemTypeBrands query)
            => await _itemTypeBrandRepository.GetAll(query.ItemTypeId);
    }
}
