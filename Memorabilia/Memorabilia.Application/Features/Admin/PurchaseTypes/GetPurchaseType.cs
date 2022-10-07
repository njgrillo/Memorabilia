using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public class GetPurchaseType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _purchaseTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
