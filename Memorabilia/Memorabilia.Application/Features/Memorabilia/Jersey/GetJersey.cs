using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Jersey
{
    public class GetJersey
    {
        public class Handler : QueryHandler<Query, JerseyViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<JerseyViewModel> Handle(Query query)
            {
                var memorabilia = await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false);

                var viewModel = new JerseyViewModel(memorabilia);

                return viewModel;
            }
        }

        public class Query : IQuery<JerseyViewModel>
        {
            public Query(int memorabiliaId)
            {
                MemorabiliaId = memorabiliaId;
            }

            public int MemorabiliaId { get; }
        }
    }
}
