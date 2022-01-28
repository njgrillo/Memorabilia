using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.Brand
{
    public class GetBrand
    {
        public class Handler : QueryHandler<DomainQuery, DomainViewModel>
        {
            private readonly IBrandRepository _brandRepository;

            public Handler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            protected override async Task<DomainViewModel> Handle(DomainQuery query)
            {
                var brand = await _brandRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(brand);

                return viewModel;
            }
        }
    }
}
