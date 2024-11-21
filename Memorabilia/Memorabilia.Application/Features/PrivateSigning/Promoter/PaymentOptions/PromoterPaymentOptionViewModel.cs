namespace Memorabilia.Application.Features.PrivateSigning.Promoter.PaymentOptions;

public class PromoterPaymentOptionViewModel
{
    private readonly Entity.PromoterPaymentOption _promoterPaymentOption;

    public PromoterPaymentOptionViewModel() { }

    public PromoterPaymentOptionViewModel(Entity.PromoterPaymentOption promoterPaymentOption)
    {
        _promoterPaymentOption = promoterPaymentOption;
    }

    public string PaymentMethodHandle
        => _promoterPaymentOption.PaymentMethodHandle;

    public Constant.PrivateSigningPaymentMethod PrivateSigningPaymentMethod
        => Constant.PrivateSigningPaymentMethod.Find(PrivateSigningPaymentMethodId);

    public int PrivateSigningPaymentMethodId 
        => _promoterPaymentOption.PrivateSigningPaymentMethodId;

    public UserModel User
        => new UserModel(_promoterPaymentOption.User);

    public int UserId
        => _promoterPaymentOption.UserId;
}
