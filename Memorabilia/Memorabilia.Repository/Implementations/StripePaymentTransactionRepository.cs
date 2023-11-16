namespace Memorabilia.Repository.Implementations;

public class StripePaymentTransactionRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<StripePaymentTransaction>(context, memoryCache), IStripePaymentTransactionRepository
{
    public async Task<StripePaymentTransaction> Get(string orderId)
        => await Items.SingleOrDefaultAsync(transaction => transaction.OrderId == orderId);
}
