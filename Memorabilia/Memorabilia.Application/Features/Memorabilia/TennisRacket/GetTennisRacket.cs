namespace Memorabilia.Application.Features.Memorabilia.TennisRacket;

public record GetTennisRacket(int MemorabiliaId) : IQuery<TennisRacketViewModel>
{
    public class Handler : QueryHandler<GetTennisRacket, TennisRacketViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<TennisRacketViewModel> Handle(GetTennisRacket query)
        {
            return new TennisRacketViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
