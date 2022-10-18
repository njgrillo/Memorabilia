using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Brands;

public record SaveBrand(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveBrand>
    {
        private readonly IDomainRepository<Brand> _brandRepository;

        public Handler(IDomainRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        protected override async Task Handle(SaveBrand request)
        {
            Brand brand;

            if (request.ViewModel.IsNew)
            {
                brand = new Brand(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _brandRepository.Add(brand);

                return;
            }

            brand = await _brandRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _brandRepository.Delete(brand);

                return;
            }

            brand.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _brandRepository.Update(brand);
        }
    }
}
