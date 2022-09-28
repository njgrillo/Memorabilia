namespace Memorabilia.Application.Features.Admin.Colleges
{
    public class GetColleges
    {
        public class Handler : QueryHandler<Query, CollegesViewModel>
        {
            private readonly ICollegeRepository _collegeRepository;

            public Handler(ICollegeRepository collegeRepository)
            {
                _collegeRepository = collegeRepository;
            }

            protected override async Task<CollegesViewModel> Handle(Query query)
            {
                return new CollegesViewModel(await _collegeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<CollegesViewModel> { }
    }
}
