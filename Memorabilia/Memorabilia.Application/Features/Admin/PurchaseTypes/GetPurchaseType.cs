using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public record GetPurchaseType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetPurchaseType, DomainViewModel>
    {
        private readonly IDomainRepository<PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetPurchaseType query)
        {
            return new DomainViewModel(await _purchaseTypeRepository.Get(query.Id));
        }
    }
}
