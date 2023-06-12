namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public record GetItemTypeSize(int Id) : IQuery<Entity.ItemTypeSize>
{
    public class Handler : QueryHandler<GetItemTypeSize, Entity.ItemTypeSize>
    {
        private readonly IItemTypeSizeRepository _itemTypeSizeRepository;

        public Handler(IItemTypeSizeRepository itemTypeSizeRepository)
        {
            _itemTypeSizeRepository = itemTypeSizeRepository;
        }

        protected override async Task<Entity.ItemTypeSize> Handle(GetItemTypeSize query)
            => await _itemTypeSizeRepository.Get(query.Id);
    }
}
