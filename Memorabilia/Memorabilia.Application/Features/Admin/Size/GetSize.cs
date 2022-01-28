using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Size
{
    public class GetSize
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly ISizeRepository _sizeRepository;

            public Handler(ISizeRepository sizeRepository)
            {
                _sizeRepository = sizeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var size = await _sizeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(size);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id)
            {
            }
        }
    }
}
