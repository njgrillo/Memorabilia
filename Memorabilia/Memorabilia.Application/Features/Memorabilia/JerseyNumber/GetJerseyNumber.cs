namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber;

public record GetJerseyNumber(int MemorabiliaId) : IQuery<JerseyNumberViewModel>
{
    public class Handler : QueryHandler<GetJerseyNumber, JerseyNumberViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<JerseyNumberViewModel> Handle(GetJerseyNumber query)
        {
            return new JerseyNumberViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
