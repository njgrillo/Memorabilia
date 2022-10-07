namespace Memorabilia.Application.Features.Memorabilia.Card;

public class GetCard
{
    public class Handler : QueryHandler<Query, CardViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<CardViewModel> Handle(Query query)
        {
            return new CardViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<CardViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
