namespace Memorabilia.Application.Features.Memorabilia.CompactDisc;

public record GetCompactDisc(int MemorabiliaId) : IQuery<CompactDiscViewModel>
{
    public class Handler : QueryHandler<GetCompactDisc, CompactDiscViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<CompactDiscViewModel> Handle(GetCompactDisc query)
        {
            return new CompactDiscViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
