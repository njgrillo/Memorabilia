namespace Memorabilia.Application.Features.Memorabilia.Document;

public record GetDocument(int MemorabiliaId) : IQuery<DocumentViewModel>
{
    public class Handler : QueryHandler<GetDocument, DocumentViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<DocumentViewModel> Handle(GetDocument query)
        {
            return new DocumentViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
