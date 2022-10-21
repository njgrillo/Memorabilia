namespace Memorabilia.Application.Features.Memorabilia.Poster;

public record GetPoster(int MemorabiliaId) : IQuery<PosterViewModel>
{
    public class Handler : QueryHandler<GetPoster, PosterViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PosterViewModel> Handle(GetPoster query)
        {
            return new PosterViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
