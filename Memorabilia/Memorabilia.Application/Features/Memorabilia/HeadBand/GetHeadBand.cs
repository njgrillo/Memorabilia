namespace Memorabilia.Application.Features.Memorabilia.HeadBand;

public record GetHeadBand(int MemorabiliaId) : IQuery<HeadBandViewModel>
{
    public class Handler : QueryHandler<GetHeadBand, HeadBandViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<HeadBandViewModel> Handle(GetHeadBand query)
        {
            return new HeadBandViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
