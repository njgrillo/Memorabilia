namespace Memorabilia.Application.Features.Memorabilia.Basketball;

public record GetBasketball(int MemorabiliaId) : IQuery<BasketballViewModel>
{
    public class Handler : QueryHandler<GetBasketball, BasketballViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<BasketballViewModel> Handle(GetBasketball query)
        {
            return new BasketballViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
