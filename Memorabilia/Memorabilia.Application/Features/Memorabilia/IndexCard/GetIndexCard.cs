namespace Memorabilia.Application.Features.Memorabilia.IndexCard;

public record GetIndexCard(int MemorabiliaId) : IQuery<IndexCardViewModel>
{
    public class Handler : QueryHandler<GetIndexCard, IndexCardViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<IndexCardViewModel> Handle(GetIndexCard query)
        {
            return new IndexCardViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
