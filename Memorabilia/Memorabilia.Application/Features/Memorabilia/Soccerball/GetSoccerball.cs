namespace Memorabilia.Application.Features.Memorabilia.Soccerball;

public class GetSoccerball
{
    public class Handler : QueryHandler<Query, SoccerballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<SoccerballViewModel> Handle(Query query)
        {
            return new SoccerballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<SoccerballViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
