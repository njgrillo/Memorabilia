using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Dashboard;

public record GetEstimatedValueData() 
    : IQuery<DashboardChartModel>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaItemRepository,
                         IAutographRepository autographRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetEstimatedValueData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetEstimatedValueData query)
        {
            decimal autographsEstimatedValueTotal 
                = autographRepository.GetEstimatedValueTotal(applicationStateService.CurrentUser.Id);

            decimal memorabiliaEstimatedValueTotal 
                = memorabiliaItemRepository.GetEstimatedValueTotal(applicationStateService.CurrentUser.Id);

            var labels = new List<string>() 
            { 
                $"Memorabilia ({memorabiliaEstimatedValueTotal:C})", 
                $"Autographs ({autographsEstimatedValueTotal:C})" 
            }.ToArray();

            var data = new List<double>() 
            { 
                (double)memorabiliaEstimatedValueTotal, 
                (double)autographsEstimatedValueTotal 
            }.ToArray();

            return await Task.FromResult(new DashboardChartModel(data, labels));
        }
    }
}
