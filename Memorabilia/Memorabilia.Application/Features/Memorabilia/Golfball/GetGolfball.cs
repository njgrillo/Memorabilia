namespace Memorabilia.Application.Features.Memorabilia.Golfball;

public class GetGolfball
{
    public class Handler : QueryHandler<Query, GolfballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<GolfballViewModel> Handle(Query query)
        {
            return new GolfballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<GolfballViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
