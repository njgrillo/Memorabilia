namespace Memorabilia.Application.Features.Memorabilia.Magazine;

public record GetMagazine(int MemorabiliaId) : IQuery<MagazineViewModel>
{
    public class Handler : QueryHandler<GetMagazine, MagazineViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MagazineViewModel> Handle(GetMagazine query)
        {
            return new MagazineViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
