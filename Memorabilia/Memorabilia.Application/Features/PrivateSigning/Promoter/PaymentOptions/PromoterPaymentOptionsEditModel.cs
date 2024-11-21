namespace Memorabilia.Application.Features.PrivateSigning.Promoter.PaymentOptions;

public class PromoterPaymentOptionsEditModel : EditModel
{
    public PromoterPaymentOptionsEditModel() { }

    public PromoterPaymentOptionsEditModel(Entity.PromoterPaymentOption[] promoterPaymentOptions, int userId)
    {
        PaymentOptions =
            promoterPaymentOptions.Select(option => new PromoterPaymentOptionEditModel(option))
                                  .ToList();

        UserId = userId;
    }

    public List<PromoterPaymentOptionEditModel> PaymentOptions { get; set; }
        = [];

    public int UserId { get; set; }
}
