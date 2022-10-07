namespace Memorabilia.Application.Features.Memorabilia.Magazine;

public class GetMagazine
{
    public class Handler : QueryHandler<Query, MagazineViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MagazineViewModel> Handle(Query query)
        {
            return new MagazineViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<MagazineViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
