namespace Memorabilia.Application.Features.Memorabilia.Football;

public class GetFootball
{
    public class Handler : QueryHandler<Query, FootballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<FootballViewModel> Handle(Query query)
        {
            return new FootballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<FootballViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
