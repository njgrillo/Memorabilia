namespace Memorabilia.Application.Features.Memorabilia.Trunks;

public record GetTrunk(int MemorabiliaId) : IQuery<TrunkViewModel>
{
    public class Handler : QueryHandler<GetTrunk, TrunkViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<TrunkViewModel> Handle(GetTrunk query)
        {
            return new TrunkViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
