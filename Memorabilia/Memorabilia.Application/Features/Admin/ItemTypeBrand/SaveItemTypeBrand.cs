namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public record SaveItemTypeBrand(SaveItemTypeBrandViewModel ViewModel) : ICommand
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
            Domain.Entities.ItemTypeBrand itemTypeBrand;

            if (request.ViewModel.IsNew)
            {
                itemTypeBrand = new Domain.Entities.ItemTypeBrand(request.ViewModel.ItemTypeId, request.ViewModel.BrandId);

                await _itemTypeBrandRepository.Add(itemTypeBrand);

                return;
            }

            itemTypeBrand = await _itemTypeBrandRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _itemTypeBrandRepository.Delete(itemTypeBrand);

                return;
            }

            itemTypeBrand.Set(request.ViewModel.BrandId);

            await _itemTypeBrandRepository.Update(itemTypeBrand);
        }
    }
}
