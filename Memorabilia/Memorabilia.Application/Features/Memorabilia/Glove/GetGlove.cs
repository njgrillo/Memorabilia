namespace Memorabilia.Application.Features.Memorabilia.Glove;

public record GetGlove(int MemorabiliaId) : IQuery<GloveViewModel>
{
    public class Handler : QueryHandler<GetGlove, GloveViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<GloveViewModel> Handle(GetGlove query)
        {
            return new GloveViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
