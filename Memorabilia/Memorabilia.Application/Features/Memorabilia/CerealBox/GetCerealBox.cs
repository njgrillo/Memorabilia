namespace Memorabilia.Application.Features.Memorabilia.CerealBox;

public class GetCerealBox
{
    public class Handler : QueryHandler<Query, CerealBoxViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<CerealBoxViewModel> Handle(Query query)
        {
            return new CerealBoxViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<CerealBoxViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
