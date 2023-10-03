namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetItemTypeLevel(int Id) : IQuery<Entity.ItemTypeLevel>
{
    public class Handler : QueryHandler<GetItemTypeLevel, Entity.ItemTypeLevel>
    {
        private readonly IItemTypeLevelRepository _itemTypeLevelRepository;

        public Handler(IItemTypeLevelRepository itemTypeLevelRepository)
        {
            _itemTypeLevelRepository = itemTypeLevelRepository;
        }

        protected override async Task<Entity.ItemTypeLevel> Handle(GetItemTypeLevel query)
            => await _itemTypeLevelRepository.Get(query.Id);
    }
}
