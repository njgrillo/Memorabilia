namespace Memorabilia.Application.Features.Memorabilia.Baseball;

public record GetBaseball(int MemorabiliaId) : IQuery<BaseballViewModel>
{
    public class Handler : QueryHandler<GetBaseball, BaseballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BaseballViewModel> Handle(GetBaseball request)
        {
            return new BaseballViewModel(await _memorabiliaRepository.Get(request.MemorabiliaId));
        }
    }
}
