namespace Memorabilia.Application.Features.Memorabilia.Document;

public class GetDocument
{
    public class Handler : QueryHandler<Query, DocumentViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<DocumentViewModel> Handle(Query query)
        {
            return new DocumentViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<DocumentViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
