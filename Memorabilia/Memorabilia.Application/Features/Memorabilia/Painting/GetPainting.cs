namespace Memorabilia.Application.Features.Memorabilia.Painting;

public class GetPainting
{
    public class Handler : QueryHandler<Query, PaintingViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PaintingViewModel> Handle(Query query)
        {
            return new PaintingViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<PaintingViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
