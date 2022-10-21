namespace Memorabilia.Application.Features.Memorabilia.CerealBox;

public record GetCerealBox(int MemorabiliaId) : IQuery<CerealBoxViewModel>
{
    public class Handler : QueryHandler<GetCerealBox, CerealBoxViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<CerealBoxViewModel> Handle(GetCerealBox query)
        {
            return new CerealBoxViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
