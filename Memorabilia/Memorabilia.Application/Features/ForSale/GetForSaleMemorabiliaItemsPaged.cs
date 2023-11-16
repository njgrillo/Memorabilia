using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.ForSale;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetForSaleMemorabiliaItemsPaged(PageInfo PageInfo,
                                              MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<ForSaleModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IMemorabiliaForSaleRepository memorabiliaForSaleRepository) 
        : QueryHandler<GetForSaleMemorabiliaItemsPaged, ForSaleModel>
    {
        protected override async Task<ForSaleModel> Handle(GetForSaleMemorabiliaItemsPaged query)
        {
            PagedResult<Entity.MemorabiliaForSale> result 
                = await memorabiliaForSaleRepository.GetAllForSale(applicationStateService.CurrentUser.Id,
                                                                   query.PageInfo,
                                                                   query.MemorabiliaSearchCriteria);

            return new ForSaleModel(result.Data, result.PageInfo);
        }
    }
}
