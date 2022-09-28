namespace Memorabilia.Application.Features.Admin.Colleges
{
    public class GetCollege
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly ICollegeRepository _collegeRepository;

            public Handler(ICollegeRepository collegeRepository)
            {
                _collegeRepository = collegeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _collegeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
