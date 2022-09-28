namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber
{
    public class GetJerseyNumber
    {
        public class Handler : QueryHandler<Query, JerseyNumberViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<JerseyNumberViewModel> Handle(Query query)
            {
                return new JerseyNumberViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<JerseyNumberViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
