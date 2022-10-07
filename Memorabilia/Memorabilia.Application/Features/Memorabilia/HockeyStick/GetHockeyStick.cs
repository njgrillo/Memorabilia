namespace Memorabilia.Application.Features.Memorabilia.HockeyStick;

public class GetHockeyStick
{
    public class Handler : QueryHandler<Query, HockeyStickViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<HockeyStickViewModel> Handle(Query query)
        {
            return new HockeyStickViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<HockeyStickViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
