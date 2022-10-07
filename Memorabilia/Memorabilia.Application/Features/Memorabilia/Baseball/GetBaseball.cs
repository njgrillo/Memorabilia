namespace Memorabilia.Application.Features.Memorabilia.Baseball;

public class GetBaseball
{
    public class Handler : QueryHandler<Query, BaseballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BaseballViewModel> Handle(Query query)
        {
            return new BaseballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<BaseballViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
