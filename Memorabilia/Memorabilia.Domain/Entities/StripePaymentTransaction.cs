namespace Memorabilia.Domain.Entities;

public class StripePaymentTransaction : Entity
{
    public StripePaymentTransaction() { }

    public StripePaymentTransaction(string orderId,
                                    int purchaseUserId,
                                    DateTime transactionDate,
                                    int stripePaymentStatusTypeId)
    {
        OrderId = orderId;
        PurchaseUserId = purchaseUserId;
        TransactionDate = transactionDate;
        StripePaymentStatusTypeId = stripePaymentStatusTypeId;
    }

    public string OrderId { get; private set; }

    public virtual User PurchaseUser { get; private set; }

    public int PurchaseUserId { get; private set; }

    public DateTime TransactionDate { get; set; }

    public int StripePaymentStatusTypeId { get; set; }

    public void SetStatus(int stripePaymentStatusTypeId)
    {
        StripePaymentStatusTypeId = stripePaymentStatusTypeId;
    }
}
