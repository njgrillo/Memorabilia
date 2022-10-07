namespace Memorabilia.Application.Features.Memorabilia.Canvas;

public class GetCanvas
{
    public class Handler : QueryHandler<Query, CanvasViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<CanvasViewModel> Handle(Query query)
        {
            return new CanvasViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<CanvasViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
