namespace Memorabilia.Application.Features.Memorabilia.Card;

public record GetCard(int MemorabiliaId) : IQuery<CardViewModel>
{
    public class Handler : QueryHandler<GetCard, CardViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<CardViewModel> Handle(GetCard query)
        {
            return new CardViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
