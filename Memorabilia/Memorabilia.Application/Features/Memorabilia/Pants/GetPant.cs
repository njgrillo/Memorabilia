namespace Memorabilia.Application.Features.Memorabilia.Pants;

public record GetPant(int MemorabiliaId) : IQuery<PantViewModel>
{
    public class Handler : QueryHandler<GetPant, PantViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PantViewModel> Handle(GetPant query)
        {
            return new PantViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
