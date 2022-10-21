namespace Memorabilia.Application.Features.Memorabilia.Figure;

public record GetFigure(int MemorabiliaId) : IQuery<FigureViewModel>
{
    public class Handler : QueryHandler<GetFigure, FigureViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<FigureViewModel> Handle(GetFigure query)
        {
            return new FigureViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
