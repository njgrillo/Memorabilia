namespace Memorabilia.Application.Core.Payments.Stripe;

public record GetStripePaymentTransaction(string OrderId)
    : IQuery<Entity.StripePaymentTransaction>
{
    public class Handler : QueryHandler<GetStripePaymentTransaction, Entity.StripePaymentTransaction>
    {
        private readonly IStripePaymentTransactionRepository _stripePaymentTransactionRepository;

        public Handler(IStripePaymentTransactionRepository stripePaymentTransactionRepository)
        {
            _stripePaymentTransactionRepository = stripePaymentTransactionRepository;
        }

        protected override async Task<Entity.StripePaymentTransaction> Handle(GetStripePaymentTransaction query)
            => await _stripePaymentTransactionRepository.Get(query.OrderId);
    }
}
