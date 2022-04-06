using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Sizes
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
                return new SizesViewModel(await _sizeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<SizesViewModel> { }
    }
}
