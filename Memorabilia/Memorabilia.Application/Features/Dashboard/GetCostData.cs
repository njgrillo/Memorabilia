using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Dashboard;

public record GetCostData() : IQuery<DashboardChartModel>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaItemRepository,
                         IAutographRepository autographRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetCostData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetCostData query)
        {
            decimal autographsCostTotal 
                = autographRepository.GetCostTotal(applicationStateService.CurrentUser.Id);

            decimal memorabiliaCostTotal 
                = memorabiliaItemRepository.GetCostTotal(applicationStateService.CurrentUser.Id);
            
            var labels = new List<string>() 
            { 
                $"Memorabilia ({memorabiliaCostTotal:C})", 
                $"Autographs ({autographsCostTotal:C})" 
            }.ToArray();

            var data = new List<double>() 
            { 
                (double)memorabiliaCostTotal, 
                (double)autographsCostTotal 
            }.ToArray();

            return await Task.FromResult(new DashboardChartModel(data, labels));
        }
    }
}
