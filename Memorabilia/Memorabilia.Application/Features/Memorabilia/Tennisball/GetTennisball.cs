namespace Memorabilia.Application.Features.Memorabilia.Tennisball;

public record GetTennisball(int MemorabiliaId) : IQuery<TennisballViewModel>
{
    public class Handler : QueryHandler<GetTennisball, TennisballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<TennisballViewModel> Handle(GetTennisball query)
        {
            return new TennisballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
