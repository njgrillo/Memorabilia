namespace Memorabilia.Application.Features.ForSale;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetForSaleSummary()
    : IQuery<ForSaleSummaryModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IMemorabiliaForSaleRepository memorabiliaForSaleRepository)
        : QueryHandler<GetForSaleSummary, ForSaleSummaryModel>
    {
        protected override async Task<ForSaleSummaryModel> Handle(GetForSaleSummary query)
        {
            ForSaleSummary result
                = await memorabiliaForSaleRepository.GetSummary(applicationStateService.CurrentUser.Id);

            return new ForSaleSummaryModel(result);
        }
    }
}
