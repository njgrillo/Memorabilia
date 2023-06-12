namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public record GetItemTypeLevels(int? ItemTypeId = null) : IQuery<Entity.ItemTypeLevel[]>
{
    public class Handler : QueryHandler<GetItemTypeLevels, Entity.ItemTypeLevel[]>
    {
        private readonly IItemTypeLevelRepository _itemTypeLevelRepository;

        public Handler(IItemTypeLevelRepository itemTypeLevelRepository)
        {
            _itemTypeLevelRepository = itemTypeLevelRepository;
        }

        protected override async Task<Entity.ItemTypeLevel[]> Handle(GetItemTypeLevels query)
            => (await _itemTypeLevelRepository.GetAll(query.ItemTypeId))
                    .ToArray();
    }
}
