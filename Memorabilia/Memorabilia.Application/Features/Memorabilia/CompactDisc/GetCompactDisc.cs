namespace Memorabilia.Application.Features.Memorabilia.CompactDisc;

public class GetCompactDisc
{
    public class Handler : QueryHandler<Query, CompactDiscViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<CompactDiscViewModel> Handle(Query query)
        {
            return new CompactDiscViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<CompactDiscViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
