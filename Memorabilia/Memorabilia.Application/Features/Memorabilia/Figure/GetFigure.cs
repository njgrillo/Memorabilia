namespace Memorabilia.Application.Features.Memorabilia.Figure;

public class GetFigure
{
    public class Handler : QueryHandler<Query, FigureViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<FigureViewModel> Handle(Query query)
        {
            return new FigureViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<FigureViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
