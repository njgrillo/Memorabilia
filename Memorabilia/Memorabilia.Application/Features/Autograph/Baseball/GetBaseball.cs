using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph.Baseball
{
    public class GetBaseball
    {
        public class Handler : QueryHandler<Query, BaseballViewModel>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task<BaseballViewModel> Handle(Query query)
            {
                var autograph = await _autographRepository.Get(query.AutographId).ConfigureAwait(false);

                var viewModel = new BaseballViewModel(autograph);

                return viewModel;
            }
        }

        public class Query : IQuery<BaseballViewModel>
        {
            public Query(int autographId)
            {
                AutographId = autographId;
            }

            public int AutographId { get; }
        }
    }
}
