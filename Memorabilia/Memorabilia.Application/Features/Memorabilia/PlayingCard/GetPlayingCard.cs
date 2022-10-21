namespace Memorabilia.Application.Features.Memorabilia.PlayingCard;

public record GetPlayingCard(int MemorabiliaId) : IQuery<PlayingCardViewModel>
{
    public class Handler : QueryHandler<GetPlayingCard, PlayingCardViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PlayingCardViewModel> Handle(GetPlayingCard query)
        {
            return new PlayingCardViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
