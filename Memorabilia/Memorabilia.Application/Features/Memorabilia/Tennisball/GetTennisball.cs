namespace Memorabilia.Application.Features.Memorabilia.Tennisball;

public class GetTennisball
{
    public class Handler : QueryHandler<Query, TennisballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<TennisballViewModel> Handle(Query query)
        {
            return new TennisballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<TennisballViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
