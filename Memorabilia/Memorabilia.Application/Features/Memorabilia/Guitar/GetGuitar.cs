namespace Memorabilia.Application.Features.Memorabilia.Guitar;

public class GetGuitar
{
    public class Handler : QueryHandler<Query, GuitarViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<GuitarViewModel> Handle(Query query)
        {
            return new GuitarViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<GuitarViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
