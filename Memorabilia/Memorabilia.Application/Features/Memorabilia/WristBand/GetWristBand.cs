namespace Memorabilia.Application.Features.Memorabilia.WristBand;

public class GetWristBand
{
    public class Handler : QueryHandler<Query, WristBandViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<WristBandViewModel> Handle(Query query)
        {
            return new WristBandViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<WristBandViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
