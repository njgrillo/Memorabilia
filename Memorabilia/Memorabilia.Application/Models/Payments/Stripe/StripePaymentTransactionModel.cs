namespace Memorabilia.Application.Models.Payments.Stripe;

public class StripePaymentTransactionModel
{
	private readonly Entity.StripePaymentTransaction _stripePaymentTransaction;

	public StripePaymentTransactionModel() { }

	public StripePaymentTransactionModel(Entity.StripePaymentTransaction stripePaymentTransaction)
	{
		_stripePaymentTransaction = stripePaymentTransaction;
    }

	public int Id 
		=> _stripePaymentTransaction.Id;

	public string OrderId
		=> _stripePaymentTransaction.OrderId;

	public UserModel PurchaseUser
		=> new(_stripePaymentTransaction.PurchaseUser);

	public int PurchaseUserId
		=> _stripePaymentTransaction.PurchaseUserId;

	public Constant.StripePaymentStatusType StripePaymentStatusType
		=> Constant.StripePaymentStatusType.Find(StripePaymentStatusTypeId);

    public int StripePaymentStatusTypeId
		=> _stripePaymentTransaction.StripePaymentStatusTypeId;

	public string StripePaymentStatusTypeName
        => StripePaymentStatusType?.Name;
}
