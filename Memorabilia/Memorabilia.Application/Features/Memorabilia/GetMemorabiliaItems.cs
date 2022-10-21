namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItems(int UserId) : IQuery<MemorabiliaItemsViewModel>
{
    public class Handler : QueryHandler<GetMemorabiliaItems, MemorabiliaItemsViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliaItemsViewModel> Handle(GetMemorabiliaItems query)
        {
            return new MemorabiliaItemsViewModel(await _memorabiliaRepository.GetAll(query.UserId));
        }
    }
}
