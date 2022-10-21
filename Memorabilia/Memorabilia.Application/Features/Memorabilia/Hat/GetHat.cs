namespace Memorabilia.Application.Features.Memorabilia.Hat;

public record GetHat(int MemorabiliaId) : IQuery<HatViewModel>
{
    public class Handler : QueryHandler<GetHat, HatViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<HatViewModel> Handle(GetHat query)
        {
            return new HatViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
