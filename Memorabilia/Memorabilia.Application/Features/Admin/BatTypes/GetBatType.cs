using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BatTypes;

public class GetBatType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<BatType> _batTypeRepository;

        public Handler(IDomainRepository<BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _batTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
