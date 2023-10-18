namespace Memorabilia.Repository.Interfaces;

public interface IStripePaymentTransactionRepository 
    : IDomainRepository<StripePaymentTransaction>
{
    Task<StripePaymentTransaction> Get(string orderId);
}
