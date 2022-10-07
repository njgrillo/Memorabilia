namespace Memorabilia.Application.Features.Memorabilia;

public class GetMemorabiliaItems
{
    public class Handler : QueryHandler<Query, MemorabiliaItemsViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliaItemsViewModel> Handle(Query query)
        {
            return new MemorabiliaItemsViewModel(await _memorabiliaRepository.GetAll(query.UserId));
        }
    }

    public class Query : IQuery<MemorabiliaItemsViewModel>
    {
        public Query(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
