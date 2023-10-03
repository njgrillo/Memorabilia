namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetPurchaseTypes() : IQuery<Entity.PurchaseType[]>
{
    public class Handler : QueryHandler<GetPurchaseTypes, Entity.PurchaseType[]>
    {
        private readonly IDomainRepository<Entity.PurchaseType> _purchaseTypeRepository;

        public Handler(IDomainRepository<Entity.PurchaseType> purchaseTypeRepository)
        {
            _purchaseTypeRepository = purchaseTypeRepository;
        }

        protected override async Task<Entity.PurchaseType[]> Handle(GetPurchaseTypes query)
            => await _purchaseTypeRepository.GetAll();
    }
}
