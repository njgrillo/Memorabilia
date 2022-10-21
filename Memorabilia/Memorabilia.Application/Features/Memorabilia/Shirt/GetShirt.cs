namespace Memorabilia.Application.Features.Memorabilia.Shirt;

public record GetShirt(int MemorabiliaId) : IQuery<ShirtViewModel>
{
    public class Handler : QueryHandler<GetShirt, ShirtViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<ShirtViewModel> Handle(GetShirt query)
        {
            return new ShirtViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
