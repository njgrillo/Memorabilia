namespace Memorabilia.Application.Features.Memorabilia.Canvas;

public record GetCanvas(int MemorabiliaId) : IQuery<CanvasViewModel>
{
    public class Handler : QueryHandler<GetCanvas, CanvasViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<CanvasViewModel> Handle(GetCanvas query)
        {
            return new CanvasViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
