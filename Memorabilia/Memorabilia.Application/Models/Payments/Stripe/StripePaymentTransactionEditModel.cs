namespace Memorabilia.Application.Models.Payments.Stripe;

public class StripePaymentTransactionEditModel : EditModel
{
	public StripePaymentTransactionEditModel() { }

	public StripePaymentTransactionEditModel(string orderId,
											 int purchaseUserId,
											 int stripePaymentStatusTypeId)
	{
		OrderId = orderId;
		PurchaseUserId = purchaseUserId;
		StripePaymentStatusType = Constant.StripePaymentStatusType.Find(stripePaymentStatusTypeId);
    }

	public StripePaymentTransactionEditModel(Entity.StripePaymentTransaction stripePaymentTransaction)
	{
		Id = stripePaymentTransaction.Id;
		OrderId = stripePaymentTransaction.OrderId;
		PurchaseUser = new(stripePaymentTransaction.PurchaseUser);
		PurchaseUserId = stripePaymentTransaction.PurchaseUserId;
		StripePaymentStatusType = Constant.StripePaymentStatusType.Find(stripePaymentTransaction.StripePaymentStatusTypeId);
    }

	public string OrderId { get; set; }

	public UserModel PurchaseUser { get; set; }
		= new();

	public int PurchaseUserId { get; set; }

	public Constant.StripePaymentStatusType StripePaymentStatusType { get; set; }

	public DateTime TransactionDate { get; set; }
}
