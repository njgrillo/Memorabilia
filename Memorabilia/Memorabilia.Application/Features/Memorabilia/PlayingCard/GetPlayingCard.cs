namespace Memorabilia.Application.Features.Memorabilia.PlayingCard
{
    public class GetPlayingCard
    {
        public class Handler : QueryHandler<Query, PlayingCardViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<PlayingCardViewModel> Handle(Query query)
            {
                return new PlayingCardViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<PlayingCardViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
