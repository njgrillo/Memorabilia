namespace Memorabilia.Application.Services.Payments.Stripe;

public class StripeService
{
    private readonly IMediator _mediator;
    private readonly IStripeSettings _stripeSettings;

    public StripeService(IMediator mediator,        
                         IStripeSettings stripeSettings)
    {
        _mediator = mediator;
        _stripeSettings = stripeSettings; 
    }

    public async Task<DateTime?> CancelSubscriptionAsync(string subscriptionId,
                                                         CancellationToken cancellationToken = default)
    {        
        var service = new SubscriptionService();
        var options = new SubscriptionUpdateOptions { CancelAtPeriodEnd = true };
        var requestOptions = GetRequestOptions();

        await service.UpdateAsync(subscriptionId, options, requestOptions, cancellationToken);

        Subscription subscription
            = await service.GetAsync(subscriptionId, requestOptions: requestOptions, cancellationToken: cancellationToken);

        return subscription.CancelAt;        
    }

    public async Task<Session> CreatePaymentAsync(PaymentModel payment, 
                                                  CancellationToken cancellationToken = default)
    {
        Customer customer 
            = await CreateOrGetCustomerAsync(payment.Customer, cancellationToken);

        await SaveStripeSettings(customer, payment.Customer);

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
            Customer = customer.Id,
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

    public async Task<Subscription> GetSubscriptionAsync(string subscriptionId,
                                                         CancellationToken cancellationToken = default)
    {
        var service = new SubscriptionService();
        var requestOptions = GetRequestOptions();

        Subscription subscription
            = await service.GetAsync(subscriptionId, requestOptions: requestOptions, cancellationToken: cancellationToken);

        return subscription;
    }

    public async Task<Subscription> GetSubscriptionByCustomerAsync(string customerId,
                                                                   CancellationToken cancellationToken = default)
    {
        var service = new SubscriptionService();

        var listOptions = new SubscriptionListOptions
        {
            Customer = customerId
        };

        StripeList<Subscription> subscriptions
            = await service.ListAsync(listOptions, GetRequestOptions(), cancellationToken);

        return subscriptions.FirstOrDefault();
    }

    private async Task<Customer> CreateOrGetCustomerAsync(CustomerModel customerModel,
                                                          CancellationToken cancellationToken = default)
    {  
        var service = new CustomerService();

        var listOptions = new CustomerListOptions
        {
            Email = customerModel.Email
        };

        StripeList<Customer> result =
            await service.ListAsync(listOptions, GetRequestOptions(), cancellationToken);

        if (result.Data.Any())
            return result.Data.FirstOrDefault();

        var options = new CustomerCreateOptions
        {
            Email = customerModel.Email,
            Name = customerModel.Name
        };

        Customer customer 
            = await service.CreateAsync(options, GetRequestOptions(), cancellationToken);

        return customer;
    }    

    private RequestOptions GetRequestOptions()
        => new()
        {
            ApiKey = _stripeSettings.ApiSecret
        };

    private async Task SaveStripeSettings(Customer customer, 
                                          CustomerModel customerModel)
    {
        if (customer.Id.Equals(customerModel.Id, StringComparison.OrdinalIgnoreCase))
            return;

        Entity.User user = await _mediator.Send(new GetUser(customerModel.Email));

        await _mediator.Send(new SaveUserStripeCustomerId(user.Id, customer.Id));
    }    

    private async Task SaveTransaction(string orderId, int purchaseUserId)
    {
        StripePaymentTransactionEditModel stripePaymentTransaction
            = new(orderId, purchaseUserId, Constant.StripePaymentStatusType.Pending.Id);

        await _mediator.Send(new SaveStripePaymentTransaction.Command(stripePaymentTransaction));
    }
}
