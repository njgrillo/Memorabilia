using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Brands;

public record GetBrand(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetBrand, DomainModel>
    {
        private readonly IDomainRepository<Brand> _brandRepository;

        public Handler(IDomainRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        protected override async Task<DomainModel> Handle(GetBrand query)
        {
            return new DomainModel(await _brandRepository.Get(query.Id));
        }
    }
}
