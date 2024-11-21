namespace Memorabilia.Application.Features.PrivateSigning.Promoter.PaymentOptions;

public class PromoterPaymentOptionEditModel : EditModel
{
    public PromoterPaymentOptionEditModel() { }

    public PromoterPaymentOptionEditModel(Entity.PromoterPaymentOption promoterPaymentOption)
    {
        Id = promoterPaymentOption.Id;
        PaymentMethodHandle = promoterPaymentOption.PaymentMethodHandle;
        PrivateSigningPaymentMethodId = promoterPaymentOption.PrivateSigningPaymentMethodId;
        User = new UserEditModel(promoterPaymentOption.User);
    }

    public string PaymentMethodHandle { get; set; }

    public int PrivateSigningPaymentMethodId { get; set; }

    public string PrivateSigningPaymentMethodName
        => Constant.PrivateSigningPaymentMethod.Find(PrivateSigningPaymentMethodId)?.Name;

    public UserEditModel User { get; set; }

    public int UserId { get; set; }
}
