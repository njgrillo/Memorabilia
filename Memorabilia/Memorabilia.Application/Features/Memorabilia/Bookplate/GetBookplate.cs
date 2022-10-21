namespace Memorabilia.Application.Features.Memorabilia.Bookplate;

public record GetBookplate(int MemorabiliaId) : IQuery<BookplateViewModel>
{
    public class Handler : QueryHandler<GetBookplate, BookplateViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BookplateViewModel> Handle(GetBookplate query)
        {
            return new BookplateViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
