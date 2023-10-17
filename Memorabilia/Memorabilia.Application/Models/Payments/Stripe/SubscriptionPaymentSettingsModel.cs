namespace Memorabilia.Application.Models.Payments.Stripe;

public class SubscriptionPaymentSettingsModel
{
	public SubscriptionPaymentSettingsModel() { }

	public string SaveDefaultPaymentMethod { get; set; }
		= "on_subscription";
}
