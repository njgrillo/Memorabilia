namespace Memorabilia.Application.Features.Admin.PurchaseTypes;

public record GetPurchaseType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.PurchaseType> purchaseTypeRepository) 
        : QueryHandler<GetPurchaseType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetPurchaseType query)
            => await purchaseTypeRepository.Get(query.Id);
    }
}
