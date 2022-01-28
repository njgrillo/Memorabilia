using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Size
{
    public class GetSizes
    {
        public class Handler : QueryHandler<Query, SizesViewModel>
        {
            private readonly ISizeRepository _sizeRepository;

            public Handler(ISizeRepository sizeRepository)
            {
                _sizeRepository = sizeRepository;
            }

            protected override async Task<SizesViewModel> Handle(Query query)
            {
                var sizes = await _sizeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new SizesViewModel(sizes);

                return viewModel;
            }
        }

        public class Query : IQuery<SizesViewModel>
        {
        }
    }
}
