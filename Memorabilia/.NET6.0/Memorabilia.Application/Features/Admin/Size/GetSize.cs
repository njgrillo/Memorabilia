using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.Size
{
    public class GetSize
    {
        public class Handler : QueryHandler<DomainQuery, DomainViewModel>
        {
            private readonly ISizeRepository _sizeRepository;

            public Handler(ISizeRepository sizeRepository)
            {
                _sizeRepository = sizeRepository;
            }

            protected override async Task<DomainViewModel> Handle(DomainQuery query)
            {
                var size = await _sizeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(size);

                return viewModel;
            }
        }
    }
}
