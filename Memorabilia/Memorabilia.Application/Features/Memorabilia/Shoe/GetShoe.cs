namespace Memorabilia.Application.Features.Memorabilia.Shoe;

public record GetShoe(int MemorabiliaId) : IQuery<ShoeViewModel>
{
    public class Handler : QueryHandler<GetShoe, ShoeViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<ShoeViewModel> Handle(GetShoe query)
        {
            return new ShoeViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
