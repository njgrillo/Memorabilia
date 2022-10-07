namespace Memorabilia.Application.Features.Memorabilia.FirstDayCover;

public class GetFirstDayCover
{
    public class Handler : QueryHandler<Query, FirstDayCoverViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<FirstDayCoverViewModel> Handle(Query query)
        {
            return new FirstDayCoverViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<FirstDayCoverViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
