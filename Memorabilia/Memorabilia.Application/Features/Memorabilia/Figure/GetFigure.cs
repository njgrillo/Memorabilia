using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Figure
{
    public class GetFigure
    {
        public class Handler : QueryHandler<Query, FigureViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<FigureViewModel> Handle(Query query)
            {
                return new FigureViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<FigureViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
