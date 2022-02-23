using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Helmet
{
    public class GetHelmet
    {
        public class Handler : QueryHandler<Query, HelmetViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<HelmetViewModel> Handle(Query query)
            {
                var memorabilia = await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false);

                var viewModel = new HelmetViewModel(memorabilia);

                return viewModel;
            }
        }

        public class Query : IQuery<HelmetViewModel>
        {
            public Query(int memorabiliaId)
            {
                MemorabiliaId = memorabiliaId;
            }

            public int MemorabiliaId { get; }
        }
    }
}
