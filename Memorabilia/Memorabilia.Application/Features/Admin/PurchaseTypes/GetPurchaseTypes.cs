using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public class GetPurchaseTypes
{
    public class Handler : QueryHandler<Query, PurchaseTypesViewModel>
    {
        private readonly IDomainRepository<PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task<PurchaseTypesViewModel> Handle(Query query)
        {
            return new PurchaseTypesViewModel(await _purchaseTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<PurchaseTypesViewModel> { }
}
