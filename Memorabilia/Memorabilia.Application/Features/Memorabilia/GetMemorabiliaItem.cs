namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItem(int Id) : IQuery<MemorabiliaItemViewModel>
{
    public class Handler : QueryHandler<GetMemorabiliaItem, MemorabiliaItemViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliaItemViewModel> Handle(GetMemorabiliaItem query)
        {
            return new MemorabiliaItemViewModel(await _memorabiliaRepository.Get(query.Id));
        }
    }
}
