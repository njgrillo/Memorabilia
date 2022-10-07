namespace Memorabilia.Application.Features.Memorabilia.Helmet;

public class GetHelmet
{
    public class Handler : QueryHandler<Query, HelmetViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<HelmetViewModel> Handle(Query query)
        {
            return new HelmetViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<HelmetViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
