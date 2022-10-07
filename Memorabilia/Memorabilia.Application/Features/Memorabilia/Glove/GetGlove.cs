namespace Memorabilia.Application.Features.Memorabilia.Glove;

public class GetGlove
{
    public class Handler : QueryHandler<Query, GloveViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<GloveViewModel> Handle(Query query)
        {
            return new GloveViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<GloveViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
