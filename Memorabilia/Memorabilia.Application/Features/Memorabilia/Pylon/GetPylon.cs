namespace Memorabilia.Application.Features.Memorabilia.Pylon;

public record GetPylon(int MemorabiliaId) : IQuery<PylonViewModel>
{
    public class Handler : QueryHandler<GetPylon, PylonViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PylonViewModel> Handle(GetPylon query)
        {
            return new PylonViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
