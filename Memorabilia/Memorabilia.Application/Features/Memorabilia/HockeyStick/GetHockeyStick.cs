namespace Memorabilia.Application.Features.Memorabilia.HockeyStick;

public record GetHockeyStick(int MemorabiliaId) : IQuery<HockeyStickViewModel>
{
    public class Handler : QueryHandler<GetHockeyStick, HockeyStickViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<HockeyStickViewModel> Handle(GetHockeyStick query)
        {
            return new HockeyStickViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
