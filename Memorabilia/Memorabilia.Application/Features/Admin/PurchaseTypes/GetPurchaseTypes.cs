namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public record GetPurchaseTypes() : IQuery<Entity.PurchaseType[]>
{
    public class Handler(IDomainRepository<Entity.PurchaseType> purchaseTypeRepository) 
        : QueryHandler<GetPurchaseTypes, Entity.PurchaseType[]>
    {
        protected override async Task<Entity.PurchaseType[]> Handle(GetPurchaseTypes query)
            => await purchaseTypeRepository.GetAll();
    }
}
