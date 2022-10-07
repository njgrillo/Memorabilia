using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Occupations;

public class GetOccupation
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<Occupation> _occupationRepository;

        public Handler(IDomainRepository<Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _occupationRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
