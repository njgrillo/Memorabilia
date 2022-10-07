namespace Memorabilia.Application.Features.Memorabilia.Pants;

public class GetPant
{
    public class Handler : QueryHandler<Query, PantViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PantViewModel> Handle(Query query)
        {
            return new PantViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<PantViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
