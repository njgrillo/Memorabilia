namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public record SaveItemTypeBrand(ItemTypeBrandEditModel ItemTypeBrand) : ICommand
{
    public class Handler : CommandHandler<SaveItemTypeBrand>
    {
        private readonly IItemTypeBrandRepository _itemTypeBrandRepository;

        public Handler(IItemTypeBrandRepository itemTypeBrandRepository)
        {
            _itemTypeBrandRepository = itemTypeBrandRepository;
        }

        protected override async Task Handle(SaveItemTypeBrand request)
        {
            Entity.ItemTypeBrand itemTypeBrand;

            if (request.ItemTypeBrand.IsNew)
            {
                itemTypeBrand = new Entity.ItemTypeBrand(request.ItemTypeBrand.ItemType.Id, 
                                                         request.ItemTypeBrand.Brand.Id);

                await _itemTypeBrandRepository.Add(itemTypeBrand);

                return;
            }

            itemTypeBrand = await _itemTypeBrandRepository.Get(request.ItemTypeBrand.Id);

            if (request.ItemTypeBrand.IsDeleted)
            {
                await _itemTypeBrandRepository.Delete(itemTypeBrand);

                return;
            }

            itemTypeBrand.Set(request.ItemTypeBrand.Brand.Id);

            await _itemTypeBrandRepository.Update(itemTypeBrand);
        }
    }
}
