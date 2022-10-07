namespace Memorabilia.Application.Features.Memorabilia.Hat;

public class GetHat
{
    public class Handler : QueryHandler<Query, HatViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<HatViewModel> Handle(Query query)
        {
            return new HatViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<HatViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
