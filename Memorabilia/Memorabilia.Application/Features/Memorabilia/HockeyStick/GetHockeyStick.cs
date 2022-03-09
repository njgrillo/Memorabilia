using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.HockeyStick
{
    public class GetHockeyStick
    {
        public class Handler : QueryHandler<Query, HockeyStickViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<HockeyStickViewModel> Handle(Query query)
            {
                return new HockeyStickViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<HockeyStickViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
