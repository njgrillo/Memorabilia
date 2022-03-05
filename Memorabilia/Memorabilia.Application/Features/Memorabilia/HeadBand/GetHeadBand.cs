using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.HeadBand
{
    public class GetHeadBand
    {
        public class Handler : QueryHandler<Query, HeadBandViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<HeadBandViewModel> Handle(Query query)
            {
                var memorabilia = await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false);

                var viewModel = new HeadBandViewModel(memorabilia);

                return viewModel;
            }
        }

        public class Query : IQuery<HeadBandViewModel>
        {
            public Query(int memorabiliaId)
            {
                MemorabiliaId = memorabiliaId;
            }

            public int MemorabiliaId { get; }
        }
    }
}
