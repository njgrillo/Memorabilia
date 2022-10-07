namespace Memorabilia.Application.Features.Memorabilia.PinFlag;

public class GetPinFlag
{
    public class Handler : QueryHandler<Query, PinFlagViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PinFlagViewModel> Handle(Query query)
        {
            return new PinFlagViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<PinFlagViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
