namespace Memorabilia.Application.Features.Memorabilia.Poster;

public class GetPoster
{
    public class Handler : QueryHandler<Query, PosterViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PosterViewModel> Handle(Query query)
        {
            return new PosterViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<PosterViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
