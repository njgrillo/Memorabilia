namespace Memorabilia.Domain.Entities;

public class PromoterPaymentOption : Entity
{
    public PromoterPaymentOption() { }

    public PromoterPaymentOption(int privateSigningPaymentMethodId, string paymentMethodHandle, int userId)
    {
        PaymentMethodHandle = paymentMethodHandle;
        PrivateSigningPaymentMethodId = privateSigningPaymentMethodId;
        UserId = userId;
    }

    public string PaymentMethodHandle { get; private set; }

    public int PrivateSigningPaymentMethodId { get; private set; }

    public string PrivateSigningPaymentMethodName
        => Constant.PrivateSigningPaymentMethod.Find(PrivateSigningPaymentMethodId)?.Name;

    public virtual User User { get; private set; }

    public int UserId { get; private set; }    

    public void Set(int privateSigningPaymentMethodId, string paymentMethodHandle)
    {
        PaymentMethodHandle = paymentMethodHandle;
        PrivateSigningPaymentMethodId = privateSigningPaymentMethodId;
    }
}
