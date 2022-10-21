namespace Memorabilia.Application.Features.Memorabilia.Drum;

public record GetDrum(int MemorabiliaId) : IQuery<DrumViewModel>
{
    public class Handler : QueryHandler<GetDrum, DrumViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<DrumViewModel> Handle(GetDrum query)
        {
            return new DrumViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
