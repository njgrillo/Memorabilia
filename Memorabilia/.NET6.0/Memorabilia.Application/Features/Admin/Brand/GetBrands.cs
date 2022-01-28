using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.Brand
{
    public class GetBrands
    {
        public class Handler : QueryHandler<Query, BrandsViewModel>
        {
            private readonly IBrandRepository _brandRepository;

            public Handler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            protected override async Task<BrandsViewModel> Handle(Query query)
            {
                var brands = await _brandRepository.GetAll().ConfigureAwait(false);

                var viewModel = new BrandsViewModel(brands);

                return viewModel;
            }
        }

        public class Query : IQuery<BrandsViewModel>
        {
        }
    }
}
