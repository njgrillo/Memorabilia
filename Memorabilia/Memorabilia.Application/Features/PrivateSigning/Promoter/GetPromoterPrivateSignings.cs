using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.PrivateSigning.Promoter;

public record GetPromoterPrivateSignings(PageInfo PageInfo)
    : IQuery<PromoterPrivateSigningsModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IPrivateSigningRepository privateSigningRepository) 
        : QueryHandler<GetPromoterPrivateSignings, PromoterPrivateSigningsModel>
    {
        protected override async Task<PromoterPrivateSigningsModel> Handle(GetPromoterPrivateSignings query)
        {
            PagedResult<Entity.PrivateSigning> result
                = await privateSigningRepository.GetAll(query.PageInfo, 
                                                        applicationStateService.CurrentUser.Id);

            return new PromoterPrivateSigningsModel(result.Data, result.PageInfo);
        }
    }
}
