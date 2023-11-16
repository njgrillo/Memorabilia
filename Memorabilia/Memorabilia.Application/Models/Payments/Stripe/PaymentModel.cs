namespace Memorabilia.Application.Models.Payments.Stripe;

public class PaymentModel
{
	public PaymentModel() { }

	public PaymentModel(int purchaseUserId,
						string orderId,
						List<LineItemModel> lineItems,
						string successUrl,
						string cancelUrl,
						string mode = null)
	{
		PurchaseUserId = purchaseUserId;
		OrderId = orderId;
		LineItems = lineItems;
		SuccessUrl = successUrl;
		CancelUrl = cancelUrl;

		if (!mode.IsNullOrEmpty())
			Mode = mode;
	}

	public string CancelUrl { get; set; }

	public CustomerModel Customer { get; set; }
		= new();

	public List<LineItemModel> LineItems { get; set; }
		= [];

	public string Mode { get; set; }
		= Constant.StripePaymentMode.Payment.Name;

	public string OrderId { get; set; }

	public int PurchaseUserId { get; set; }

	public string SuccessUrl { get; set; }
}
