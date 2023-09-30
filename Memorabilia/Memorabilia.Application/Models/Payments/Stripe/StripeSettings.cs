namespace Memorabilia.Application.Models.Payments.Stripe;

public class StripeSettings : IStripeSettings
{
    public string ApiKey { get; set; }

    public string ApiSecret { get; set; }
}
