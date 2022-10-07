namespace Memorabilia.Application.Features.Memorabilia.Jersey;

public class GetJersey
{
    public class Handler : QueryHandler<Query, JerseyViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<JerseyViewModel> Handle(Query query)
        {
            return new JerseyViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<JerseyViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
