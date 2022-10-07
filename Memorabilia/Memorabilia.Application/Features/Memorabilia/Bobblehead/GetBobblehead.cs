namespace Memorabilia.Application.Features.Memorabilia.Bobblehead;

public class GetBobblehead
{
    public class Handler : QueryHandler<Query, BobbleheadViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BobbleheadViewModel> Handle(Query query)
        {
            return new BobbleheadViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<BobbleheadViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
