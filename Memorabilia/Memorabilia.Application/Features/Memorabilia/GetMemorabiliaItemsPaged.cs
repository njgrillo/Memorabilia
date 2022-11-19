namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItemsPaged(int UserId, PageInfo PageInfo, Expression<Func<Domain.Entities.Memorabilia, bool>> Filter = null) : IQuery<MemorabiliaItemsViewModel>
{
    public class Handler : QueryHandler<GetMemorabiliaItemsPaged, MemorabiliaItemsViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliaItemsViewModel> Handle(GetMemorabiliaItemsPaged query)
        {
            var result = await _memorabiliaRepository.GetAll(query.UserId, query.PageInfo, query.Filter);

            return new MemorabiliaItemsViewModel(result.Data, result.PageInfo);
        }
    }
}
