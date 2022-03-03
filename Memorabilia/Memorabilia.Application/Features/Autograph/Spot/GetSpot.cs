using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph.Spot
{
    public class GetSpot
    {
        public class Handler : QueryHandler<Query, SpotViewModel>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task<SpotViewModel> Handle(Query query)
            {
                var autograph = await _autographRepository.Get(query.AutographId).ConfigureAwait(false);

                var viewModel = new SpotViewModel(autograph);

                return viewModel;
            }
        }

        public class Query : IQuery<SpotViewModel>
        {
            public Query(int autographId)
            {
                AutographId = autographId;
            }

            public int AutographId { get; }
        }
    }
}
