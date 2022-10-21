namespace Memorabilia.Application.Features.Memorabilia.PinFlag;

public record GetPinFlag(int MemorabiliaId) : IQuery<PinFlagViewModel>
{
    public class Handler : QueryHandler<GetPinFlag, PinFlagViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PinFlagViewModel> Handle(GetPinFlag query)
        {
            return new PinFlagViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
