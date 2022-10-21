namespace Memorabilia.Application.Features.Memorabilia.Football;

public record GetFootball(int MemorabiliaId) : IQuery<FootballViewModel>
{
    public class Handler : QueryHandler<GetFootball, FootballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<FootballViewModel> Handle(GetFootball query)
        {
            return new FootballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
