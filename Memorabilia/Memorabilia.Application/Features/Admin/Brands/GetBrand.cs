using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Brands;

public record GetBrand(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetBrand, DomainViewModel>
    {
        private readonly IDomainRepository<Brand> _brandRepository;

        public Handler(IDomainRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetBrand query)
        {
            return new DomainViewModel(await _brandRepository.Get(query.Id));
        }
    }
}
