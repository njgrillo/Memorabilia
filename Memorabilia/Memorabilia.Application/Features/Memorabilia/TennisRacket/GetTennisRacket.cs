namespace Memorabilia.Application.Features.Memorabilia.TennisRacket
{
    public class GetTennisRacket
    {
        public class Handler : QueryHandler<Query, TennisRacketViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<TennisRacketViewModel> Handle(Query query)
            {
                return new TennisRacketViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<TennisRacketViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
