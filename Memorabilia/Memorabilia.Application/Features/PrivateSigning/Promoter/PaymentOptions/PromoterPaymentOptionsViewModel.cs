namespace Memorabilia.Application.Features.PrivateSigning.Promoter.PaymentOptions;

public class PromoterPaymentOptionsViewModel : Model
{
    public PromoterPaymentOptionsViewModel() { }

    public PromoterPaymentOptionsViewModel(Entity.PromoterPaymentOption[] promoterPaymentOptions)
    {
        PaymentOptions
            = promoterPaymentOptions.Select(option => new PromoterPaymentOptionViewModel(option))
                                    .ToList();
    }

    public List<PromoterPaymentOptionViewModel> PaymentOptions { get; set; }
        = [];
}
