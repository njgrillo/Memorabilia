namespace Memorabilia.Application.Core.Payments.Stripe;

public record GetStripePaymentTransaction(string OrderId)
    : IQuery<Entity.StripePaymentTransaction>
{
    public class Handler(IStripePaymentTransactionRepository stripePaymentTransactionRepository) 
        : QueryHandler<GetStripePaymentTransaction, Entity.StripePaymentTransaction>
    {
        protected override async Task<Entity.StripePaymentTransaction> Handle(GetStripePaymentTransaction query)
            => await stripePaymentTransactionRepository.Get(query.OrderId);
    }
}
