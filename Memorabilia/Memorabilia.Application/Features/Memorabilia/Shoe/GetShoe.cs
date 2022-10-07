namespace Memorabilia.Application.Features.Memorabilia.Shoe;

public class GetShoe
{
    public class Handler : QueryHandler<Query, ShoeViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<ShoeViewModel> Handle(Query query)
        {
            return new ShoeViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<ShoeViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
