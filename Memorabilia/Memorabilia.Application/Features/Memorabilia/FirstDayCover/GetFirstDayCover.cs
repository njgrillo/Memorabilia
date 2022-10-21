namespace Memorabilia.Application.Features.Memorabilia.FirstDayCover;

public record GetFirstDayCover(int MemorabiliaId) : IQuery<FirstDayCoverViewModel>
{
    public class Handler : QueryHandler<GetFirstDayCover, FirstDayCoverViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<FirstDayCoverViewModel> Handle(GetFirstDayCover query)
        {
            return new FirstDayCoverViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
