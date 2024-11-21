namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPaymentOptionEditModel : EditModel
{
    public PrivateSigningPaymentOptionEditModel() 
    { 
        TemporaryId = Guid.NewGuid();
    }

    public PrivateSigningPaymentOptionEditModel(Entity.PrivateSigningPaymentOption privateSigningPaymentOption)
    {
        Id = privateSigningPaymentOption.Id;
        PaymentMethodHandle = privateSigningPaymentOption.PaymentMethodHandle;
        PrivateSigningId = privateSigningPaymentOption.PrivateSigningId;
        PrivateSigningPaymentMethodId = privateSigningPaymentOption.PrivateSigningPaymentMethodId;
    }

    public string PaymentMethodHandle { get; set; }

    public int PrivateSigningId { get; set; }

    public int PrivateSigningPaymentMethodId { get; set; }

    public string PrivateSigningPaymentMethodName
        => Constant.PrivateSigningPaymentMethod.Find(PrivateSigningPaymentMethodId)?.Name;

    public Guid? TemporaryId { get; set; }
}
