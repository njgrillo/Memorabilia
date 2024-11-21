namespace Memorabilia.Application.Features.PrivateSigning.Promoter.PaymentOptions;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public record GetPromoterPaymentOptions() : IQuery<Entity.PromoterPaymentOption[]>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IPromoterPaymentOptionRepository promoterPaymentOptionRepository)
        : QueryHandler<GetPromoterPaymentOptions, Entity.PromoterPaymentOption[]>
    {
        protected override async Task<Entity.PromoterPaymentOption[]> Handle(GetPromoterPaymentOptions query)
            => (await promoterPaymentOptionRepository.GetAll(applicationStateService.CurrentUser.Id))
                   .OrderBy(option => option.PrivateSigningPaymentMethodName)
                   .ToArray();
    }
}
