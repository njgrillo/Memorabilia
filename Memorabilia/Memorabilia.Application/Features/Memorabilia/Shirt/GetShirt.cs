namespace Memorabilia.Application.Features.Memorabilia.Shirt;

public class GetShirt
{
    public class Handler : QueryHandler<Query, ShirtViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<ShirtViewModel> Handle(Query query)
        {
            return new ShirtViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<ShirtViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
