namespace Memorabilia.Application.Models.Payments.Stripe;

public interface IStripeSettings
{
    string ApiKey { get; set; }

    string ApiSecret { get; set; }
}
