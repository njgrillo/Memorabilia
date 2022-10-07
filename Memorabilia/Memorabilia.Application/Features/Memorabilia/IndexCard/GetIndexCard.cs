namespace Memorabilia.Application.Features.Memorabilia.IndexCard;

public class GetIndexCard
{
    public class Handler : QueryHandler<Query, IndexCardViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<IndexCardViewModel> Handle(Query query)
        {
            return new IndexCardViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<IndexCardViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
