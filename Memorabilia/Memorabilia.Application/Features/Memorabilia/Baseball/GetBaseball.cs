using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class GetBaseball
    {
        public class Handler : QueryHandler<Query, BaseballViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<BaseballViewModel> Handle(Query query)
            {                
                var memorabilia = await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false);

                var viewModel = new BaseballViewModel(memorabilia);

                return viewModel;
            }
        }

        public class Query : IQuery<BaseballViewModel>
        {
            public Query(int memorabiliaId)
            {
                MemorabiliaId = memorabiliaId;
            }

            public int MemorabiliaId { get; }
        }
    }
}
