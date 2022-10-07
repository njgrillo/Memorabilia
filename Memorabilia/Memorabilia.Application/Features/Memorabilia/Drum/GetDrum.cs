namespace Memorabilia.Application.Features.Memorabilia.Drum;

public class GetDrum
{
    public class Handler : QueryHandler<Query, DrumViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<DrumViewModel> Handle(Query query)
        {
            return new DrumViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<DrumViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
