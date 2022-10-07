namespace Memorabilia.Application.Features.Memorabilia.Bammer;

public class GetBammer
{
    public class Handler : QueryHandler<Query, BammerViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BammerViewModel> Handle(Query query)
        {
            return new BammerViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<BammerViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
