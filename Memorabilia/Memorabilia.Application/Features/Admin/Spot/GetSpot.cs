using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Spot
{
    public class GetSpot
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly ISpotRepository _spotRepository;

            public Handler(ISpotRepository spotRepository)
            {
                _spotRepository = spotRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var spot = await _spotRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(spot);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
