namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetItemTypeSizes(int? ItemTypeId = null) : IQuery<Entity.ItemTypeSize[]>
{
    public class Handler : QueryHandler<GetItemTypeSizes, Entity.ItemTypeSize[]>
    {
        private readonly IItemTypeSizeRepository _itemTypeSizeRepository;

        public Handler(IItemTypeSizeRepository itemTypeSizeRepository)
        {
            _itemTypeSizeRepository = itemTypeSizeRepository;
        }

        protected override async Task<Entity.ItemTypeSize[]> Handle(GetItemTypeSizes query)
            => await _itemTypeSizeRepository.GetAll(query.ItemTypeId);
    }
}
