namespace Memorabilia.Application.Features.Memorabilia.Guitar;

public record GetGuitar(int MemorabiliaId) : IQuery<GuitarViewModel>
{
    public class Handler : QueryHandler<GetGuitar, GuitarViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<GuitarViewModel> Handle(GetGuitar query)
        {
            return new GuitarViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
