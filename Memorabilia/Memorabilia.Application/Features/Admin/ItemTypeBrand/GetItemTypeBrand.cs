namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetItemTypeBrand(int Id) : IQuery<Entity.ItemTypeBrand>
{
    public class Handler : QueryHandler<GetItemTypeBrand, Entity.ItemTypeBrand>
    {
        private readonly IItemTypeBrandRepository _itemTypeBrandRepository;

        public Handler(IItemTypeBrandRepository itemTypeBrandRepository)
        {
            _itemTypeBrandRepository = itemTypeBrandRepository;
        }

        protected override async Task<Entity.ItemTypeBrand> Handle(GetItemTypeBrand query)
            => await _itemTypeBrandRepository.Get(query.Id);
    }
}
