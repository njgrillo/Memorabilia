using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Colleges;

public class GetCollege
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<College> _collegeRepository;

        public Handler(IDomainRepository<College> collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _collegeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
