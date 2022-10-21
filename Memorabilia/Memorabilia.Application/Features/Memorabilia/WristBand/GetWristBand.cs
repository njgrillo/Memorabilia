namespace Memorabilia.Application.Features.Memorabilia.WristBand;

public record GetWristBand(int MemorabiliaId) : IQuery<WristBandViewModel>
{
    public class Handler : QueryHandler<GetWristBand, WristBandViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<WristBandViewModel> Handle(GetWristBand query)
        {
            return new WristBandViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
