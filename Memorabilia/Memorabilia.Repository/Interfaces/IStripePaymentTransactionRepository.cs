namespace Memorabilia.Repository.Interfaces;

public interface IStripePaymentTransactionRepository 
    : IDomainRepository<Entity.StripePaymentTransaction>
{
    Task<Entity.StripePaymentTransaction> Get(string orderId);
}
