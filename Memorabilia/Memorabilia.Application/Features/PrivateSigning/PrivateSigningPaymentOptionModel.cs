namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPaymentOptionModel
{
    private readonly Entity.PrivateSigningPaymentOption _privateSigningPaymentOption;

    public PrivateSigningPaymentOptionModel() { }

    public PrivateSigningPaymentOptionModel(Entity.PrivateSigningPaymentOption privateSigningPaymentOption)
    {
        _privateSigningPaymentOption = privateSigningPaymentOption;
    }

    public string PaymentMethodHandle
        => _privateSigningPaymentOption.PaymentMethodHandle;

    public int PrivateSigningId 
        => _privateSigningPaymentOption.PrivateSigningId;

    public int PrivateSigningPaymentMethodId 
        => _privateSigningPaymentOption.PrivateSigningPaymentMethodId;
}
