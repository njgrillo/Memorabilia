namespace Memorabilia.Application.Features.Memorabilia.Book;

public class GetBook
{
    public class Handler : QueryHandler<Query, BookViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BookViewModel> Handle(Query query)
        {
            return new BookViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<BookViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
