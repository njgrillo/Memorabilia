namespace Memorabilia.Application.Features.Memorabilia.Bookplate;

public class GetBookplate
{
    public class Handler : QueryHandler<Query, BookplateViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BookplateViewModel> Handle(Query query)
        {
            return new BookplateViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<BookplateViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
