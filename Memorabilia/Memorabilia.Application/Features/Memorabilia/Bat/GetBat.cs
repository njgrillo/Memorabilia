namespace Memorabilia.Application.Features.Memorabilia.Bat;

public record GetBat(int MemorabiliaId) : IQuery<BatViewModel>
{
    public class Handler : QueryHandler<GetBat, BatViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BatViewModel> Handle(GetBat query)
        {
            return new BatViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
