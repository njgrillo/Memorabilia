namespace Memorabilia.Application.Features.Autograph
{
    public class GetAutograph
    {
        public class Handler : QueryHandler<Query, AutographViewModel>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task<AutographViewModel> Handle(Query query)
            {
                return new AutographViewModel(await _autographRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<AutographViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
