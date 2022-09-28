namespace Memorabilia.Application.Features.Admin.Brands
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
                return new BrandsViewModel(await _brandRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<BrandsViewModel> { }
    }
}
