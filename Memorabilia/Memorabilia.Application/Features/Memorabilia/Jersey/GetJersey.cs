namespace Memorabilia.Application.Features.Memorabilia.Jersey;

public record GetJersey(int MemorabiliaId) : IQuery<JerseyViewModel>
{
    public class Handler : QueryHandler<GetJersey, JerseyViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<JerseyViewModel> Handle(GetJersey query)
        {
            return new JerseyViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
