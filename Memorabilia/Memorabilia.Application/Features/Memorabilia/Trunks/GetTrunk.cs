namespace Memorabilia.Application.Features.Memorabilia.Trunks
{
    public class GetTrunk
    {
        public class Handler : QueryHandler<Query, TrunkViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<TrunkViewModel> Handle(Query query)
            {
                return new TrunkViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<TrunkViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
