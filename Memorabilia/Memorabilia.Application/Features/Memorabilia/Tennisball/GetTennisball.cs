namespace Memorabilia.Application.Features.Memorabilia.Tennisball
{
    public class GetTennisball
    {
        public class Handler : QueryHandler<Query, TennisballViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<TennisballViewModel> Handle(Query query)
            {
                return new TennisballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<TennisballViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
