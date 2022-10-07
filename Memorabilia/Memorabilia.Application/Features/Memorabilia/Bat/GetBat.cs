namespace Memorabilia.Application.Features.Memorabilia.Bat;

public class GetBat
{
    public class Handler : QueryHandler<Query, BatViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BatViewModel> Handle(Query query)
        {
            return new BatViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<BatViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
