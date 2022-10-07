namespace Memorabilia.Application.Features.Memorabilia;

public class GetMemorabiliaItem
{
    public class Handler : QueryHandler<Query, MemorabiliaItemViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliaItemViewModel> Handle(Query query)
        {
            return new MemorabiliaItemViewModel(await _memorabiliaRepository.Get(query.Id));
        }
    }

    public class Query : IQuery<MemorabiliaItemViewModel>
    {
        public Query(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
