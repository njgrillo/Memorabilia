namespace Memorabilia.Application.Features.Memorabilia.Bammer;

public record GetBammer(int MemorabiliaId) : IQuery<BammerModel>
{
    public class Handler : QueryHandler<GetBammer, BammerModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BammerModel> Handle(GetBammer query)
        {
            return new BammerModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
