namespace Memorabilia.Application.Models.Payments.Stripe;

public class SubscriptionOptionsModel
{
	public SubscriptionOptionsModel() { }

	public string CustomerId { get; set; }

	public List<SubscriptionItemOptionsModel> Items { get; set; }
		= new();

    public string PaymentBehavior { get; set; }
		= "default_incomplete";

	public SubscriptionPaymentSettingsModel PaymentSettings { get; set; }
		= new();
}
