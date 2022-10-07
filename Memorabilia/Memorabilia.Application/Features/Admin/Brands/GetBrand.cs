using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Brands;

public class GetBrand
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<Brand> _brandRepository;

        public Handler(IDomainRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _brandRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
