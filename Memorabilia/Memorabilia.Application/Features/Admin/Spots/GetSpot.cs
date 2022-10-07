using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Spots;

public class GetSpot
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<Spot> _spotRepository;

        public Handler(IDomainRepository<Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _spotRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
