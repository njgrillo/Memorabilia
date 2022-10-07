namespace Memorabilia.Application.Features.Memorabilia.Lithograph;

public class GetLithograph
{
    public class Handler : QueryHandler<Query, LithographViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<LithographViewModel> Handle(Query query)
        {
            return new LithographViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<LithographViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
