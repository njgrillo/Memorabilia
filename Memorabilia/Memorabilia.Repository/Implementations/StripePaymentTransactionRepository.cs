namespace Memorabilia.Repository.Implementations;

public class StripePaymentTransactionRepository
    : DomainRepository<StripePaymentTransaction>, IStripePaymentTransactionRepository
{
    public StripePaymentTransactionRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<StripePaymentTransaction> Get(string orderId)
        => await Items.SingleOrDefaultAsync(transaction => transaction.OrderId == orderId);
}
