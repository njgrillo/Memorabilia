using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Brands;

public record GetBrands() : IQuery<BrandsViewModel>
{
    public class Handler : QueryHandler<GetBrands, BrandsViewModel>
    {
        private readonly IDomainRepository<Brand> _brandRepository;

        public Handler(IDomainRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        protected override async Task<BrandsViewModel> Handle(GetBrands query)
        {
            return new BrandsViewModel(await _brandRepository.GetAll());
        }
    }
}
