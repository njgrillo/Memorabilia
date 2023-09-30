namespace Memorabilia.Application.Models.Payments.Stripe;

public class PaymentModel
{
	public PaymentModel() { }

	public PaymentModel(int purchaseUserId,
						List<LineItemModel> lineItems,
						string successUrl,
						string cancelUrl,
						string mode = null)
	{
		PurchaseUserId = purchaseUserId;
		LineItems = lineItems;
		SuccessUrl = successUrl;
		CancelUrl = cancelUrl;

		if (!mode.IsNullOrEmpty())
			Mode = mode;
	}

	public string CancelUrl { get; set; }

	public List<LineItemModel> LineItems { get; set; }
		= new();

	public string Mode { get; set; }
		= "payment";

	public int PurchaseUserId { get; set; }

	public string SuccessUrl { get; set; }
}
