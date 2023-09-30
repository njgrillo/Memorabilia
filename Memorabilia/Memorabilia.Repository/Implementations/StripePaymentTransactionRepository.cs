namespace Memorabilia.Repository.Implementations;

public class StripePaymentTransactionRepository
    : DomainRepository<Entity.StripePaymentTransaction>, IStripePaymentTransactionRepository
{
    public StripePaymentTransactionRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<Entity.StripePaymentTransaction> Get(string orderId)
        => await Items.SingleOrDefaultAsync(transaction => transaction.OrderId == orderId);
}
