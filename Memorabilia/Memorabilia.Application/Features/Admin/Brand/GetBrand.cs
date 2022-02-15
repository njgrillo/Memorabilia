using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Brand
{
    public class GetBrand
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IBrandRepository _brandRepository;

            public Handler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var brand = await _brandRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(brand);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
