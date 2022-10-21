namespace Memorabilia.Application.Features.Memorabilia.Bobblehead;

public record GetBobblehead(int MemorabiliaId) : IQuery<BobbleheadViewModel>
{
    public class Handler : QueryHandler<GetBobblehead, BobbleheadViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BobbleheadViewModel> Handle(GetBobblehead query)
        {
            return new BobbleheadViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
