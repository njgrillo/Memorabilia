namespace Memorabilia.Domain.Entities;

public class PrivateSigningPaymentOption : Entity
{
	public PrivateSigningPaymentOption() { }

    public PrivateSigningPaymentOption(
        int privateSigningId, 
        int privateSigningPaymentMethodId,
        string paymentMethodHandle)
    {
        PaymentMethodHandle = paymentMethodHandle;
        PrivateSigningId = privateSigningId;
        PrivateSigningPaymentMethodId = privateSigningPaymentMethodId;        
    }

    public string PaymentMethodHandle { get; private set; }

    public int PrivateSigningId { get; private set; }

	public int PrivateSigningPaymentMethodId { get; private set; }

    public void Set(
        int privateSigningId, 
        int privateSigningPaymentMethodId,
        string paymentMethodHandle
        )
    {
        PaymentMethodHandle = paymentMethodHandle;
        PrivateSigningId = privateSigningId;
        PrivateSigningPaymentMethodId = privateSigningPaymentMethodId;
    }
}
