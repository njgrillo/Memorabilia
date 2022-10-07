namespace Memorabilia.Application.Features.Memorabilia.Puck;

public class GetPuck
{
    public class Handler : QueryHandler<Query, PuckViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PuckViewModel> Handle(Query query)
        {
            return new PuckViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<PuckViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
