namespace Memorabilia.Application.Features.Memorabilia.Helmet;

public record GetHelmet(int MemorabiliaId) : IQuery<HelmetViewModel>
{
    public class Handler : QueryHandler<GetHelmet, HelmetViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<HelmetViewModel> Handle(GetHelmet query)
        {
            return new HelmetViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
