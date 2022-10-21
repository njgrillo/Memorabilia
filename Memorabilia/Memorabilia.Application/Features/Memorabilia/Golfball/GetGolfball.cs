namespace Memorabilia.Application.Features.Memorabilia.Golfball;

public record GetGolfball(int MemorabiliaId) : IQuery<GolfballViewModel>
{
    public class Handler : QueryHandler<GetGolfball, GolfballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<GolfballViewModel> Handle(GetGolfball query)
        {
            return new GolfballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
