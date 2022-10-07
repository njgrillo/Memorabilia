namespace Memorabilia.Application.Features.Memorabilia.Basketball;

public class GetBasketball
{
    public class Handler : QueryHandler<Query, BasketballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BasketballViewModel> Handle(Query query)
        {
            return new BasketballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<BasketballViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
