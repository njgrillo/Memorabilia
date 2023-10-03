using Memorabilia.Application.Core.Payments.Stripe;

namespace Memorabilia.Application.Services.Payments.Stripe;

public class StripeService
{
    private readonly CommandRouter _commandRouter;
    private readonly IDataProtectorService _dataProtectorService;
    private readonly IStripeSettings _stripeSettings;

    public StripeService(CommandRouter commandRouter,
                         IDataProtectorService dataProtectorService,
                         IStripeSettings stripeSettings)
    {
        _commandRouter = commandRouter;
        _dataProtectorService = dataProtectorService;
        _stripeSettings = stripeSettings; 
    }

    public async Task<Session> CreatePaymentAsync(PaymentModel payment, 
                                                  CancellationToken cancellationToken = default)
    {
        List<SessionLineItemOptions> lineItems
            = payment.LineItems.Select(item => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = item.Currency,
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Description = item.Product.Description,
                        Images = item.Product.ImageUrls,
                        Name = item.Product.Name,
                    },
                    Recurring = item.Recurring != null 
                        ? new SessionLineItemPriceDataRecurringOptions
                            {
                                Interval = item.Recurring.Interval,
                                IntervalCount = item.Recurring.IntervalCount,
                            }
                        : null,                    
                    UnitAmountDecimal = item.Amount
                },
                Quantity = item.Quantity
            }).ToList();

        var options = new SessionCreateOptions
        {
            CancelUrl = payment.CancelUrl,
            LineItems = lineItems,
            Mode = payment.Mode,
            SuccessUrl = payment.SuccessUrl,            
        };

        var service = new SessionService();

        Session session 
            = await service.CreateAsync(options, GetRequestOptions(), cancellationToken);

        await SaveTransaction(payment.OrderId, payment.PurchaseUserId);

        return session;
    }

    private RequestOptions GetRequestOptions()
        => new()
        {
            ApiKey = _stripeSettings.ApiSecret
        };

    private async Task SaveTransaction(string orderId, int purchaseUserId)
    {
        StripePaymentTransactionEditModel stripePaymentTransaction
            = new(orderId, purchaseUserId, Constant.StripePaymentStatusType.Pending.Id);

        await _commandRouter.Send(new SaveStripePaymentTransaction.Command(stripePaymentTransaction));
    }
}
