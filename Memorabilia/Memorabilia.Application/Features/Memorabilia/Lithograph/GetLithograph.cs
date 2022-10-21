namespace Memorabilia.Application.Features.Memorabilia.Lithograph;

public record GetLithograph(int MemorabiliaId) : IQuery<LithographViewModel>
{
    public class Handler : QueryHandler<GetLithograph, LithographViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<LithographViewModel> Handle(GetLithograph query)
        {
            return new LithographViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
