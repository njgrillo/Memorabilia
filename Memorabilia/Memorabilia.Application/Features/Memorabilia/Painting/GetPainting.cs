namespace Memorabilia.Application.Features.Memorabilia.Painting;

public record GetPainting(int MemorabiliaId) : IQuery<PaintingViewModel>
{
    public class Handler : QueryHandler<GetPainting, PaintingViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PaintingViewModel> Handle(GetPainting query)
        {
            return new PaintingViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
