namespace Memorabilia.Application.Features.Memorabilia.Puck;

public record GetPuck(int MemorabiliaId) : IQuery<PuckViewModel>
{
    public class Handler : QueryHandler<GetPuck, PuckViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PuckViewModel> Handle(GetPuck query)
        {
            return new PuckViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
