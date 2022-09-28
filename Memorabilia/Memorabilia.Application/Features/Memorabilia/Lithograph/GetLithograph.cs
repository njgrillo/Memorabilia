namespace Memorabilia.Application.Features.Memorabilia.Lithograph
{
    public class GetLithograph
    {
        public class Handler : QueryHandler<Query, LithographViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<LithographViewModel> Handle(Query query)
            {
                return new LithographViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<LithographViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
