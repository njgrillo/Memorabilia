using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Football
{
    public class GetFootball
    {
        public class Handler : QueryHandler<Query, FootballViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<FootballViewModel> Handle(Query query)
            {
                return new FootballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<FootballViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
