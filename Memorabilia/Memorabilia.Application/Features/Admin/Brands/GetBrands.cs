using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Brands;

public class GetBrands
{
    public class Handler : QueryHandler<Query, BrandsViewModel>
    {
        private readonly IDomainRepository<Brand> _brandRepository;

        public Handler(IDomainRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        protected override async Task<BrandsViewModel> Handle(Query query)
        {
            return new BrandsViewModel(await _brandRepository.GetAll());
        }
    }

    public class Query : IQuery<BrandsViewModel> { }
}
