using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BatType
{
    public class GetBatType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IBatTypeRepository _batTypeRepository;

            public Handler(IBatTypeRepository batTypeRepository)
            {
                _batTypeRepository = batTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var batType = await _batTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(batType);

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
