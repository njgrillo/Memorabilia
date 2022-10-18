namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public record GetItemTypeBrand(int Id) : IQuery<ItemTypeBrandViewModel>
{
    public class Handler : QueryHandler<GetItemTypeBrand, ItemTypeBrandViewModel>
    {
        private readonly IItemTypeBrandRepository _itemTypeBrandRepository;

        public Handler(IItemTypeBrandRepository itemTypeBrandRepository)
        {
            _itemTypeBrandRepository = itemTypeBrandRepository;
        }

        protected override async Task<ItemTypeBrandViewModel> Handle(GetItemTypeBrand query)
        {
            return new ItemTypeBrandViewModel(await _itemTypeBrandRepository.Get(query.Id));
        }
    }
}
