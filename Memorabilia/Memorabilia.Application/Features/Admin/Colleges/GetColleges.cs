using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colleges;

public class GetColleges
{
    public class Handler : QueryHandler<Query, CollegesViewModel>
    {
        private readonly IDomainRepository<College> _collegeRepository;

        public Handler(IDomainRepository<College> collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task<CollegesViewModel> Handle(Query query)
        {
            return new CollegesViewModel(await _collegeRepository.GetAll());
        }
    }

    public class Query : IQuery<CollegesViewModel> { }
}
