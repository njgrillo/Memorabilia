namespace Memorabilia.Application.Features.Memorabilia.HeadBand;

public class GetHeadBand
{
    public class Handler : QueryHandler<Query, HeadBandViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<HeadBandViewModel> Handle(Query query)
        {
            return new HeadBandViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<HeadBandViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
