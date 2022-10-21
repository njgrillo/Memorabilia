namespace Memorabilia.Application.Features.Memorabilia.Book;

public record GetBook(int MemorabiliaId) : IQuery<BookViewModel>
{
    public class Handler : QueryHandler<GetBook, BookViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BookViewModel> Handle(GetBook query)
        {
            return new BookViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
