namespace Memorabilia.Application.Features.Memorabilia.Pylon;

public class GetPylon
{
    public class Handler : QueryHandler<Query, PylonViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PylonViewModel> Handle(Query query)
        {
            return new PylonViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<PylonViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
