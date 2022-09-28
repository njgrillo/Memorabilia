namespace Memorabilia.Application.Features.Autograph
{
    public class GetAutographs
    {
        public class Handler : QueryHandler<Query, AutographsViewModel>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task<AutographsViewModel> Handle(Query query)
            {
                return new AutographsViewModel(await _autographRepository.GetAll(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<AutographsViewModel>
        {
            public Query(int? memorabiliaId = null, int? userId = null)
            {
                MemorabiliaId = memorabiliaId;
                UserId = userId;
            }

            public int? MemorabiliaId { get; }

            public int? UserId { get; }
        }
    }
}
