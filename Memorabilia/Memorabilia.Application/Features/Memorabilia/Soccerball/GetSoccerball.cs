namespace Memorabilia.Application.Features.Memorabilia.Soccerball;

public record GetSoccerball(int MemorabiliaId) : IQuery<SoccerballViewModel>
{
    public class Handler : QueryHandler<GetSoccerball, SoccerballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<SoccerballViewModel> Handle(GetSoccerball query)
        {
            return new SoccerballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
