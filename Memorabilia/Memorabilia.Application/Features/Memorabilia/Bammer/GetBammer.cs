namespace Memorabilia.Application.Features.Memorabilia.Bammer;

public record GetBammer(int MemorabiliaId) : IQuery<BammerViewModel>
{
    public class Handler : QueryHandler<GetBammer, BammerViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BammerViewModel> Handle(GetBammer query)
        {
            return new BammerViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
