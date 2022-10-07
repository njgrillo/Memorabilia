using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard;

public class BrandChartRule : DashboardItemRule, IDashboardItemRule
{
    public override DashboardItem DashboardItem { get; set; }

    public bool Applies(DashboardItem dashboardItem)
    {
        DashboardItem = dashboardItem;

        return dashboardItem == DashboardItem.BrandDonutChart ||
               dashboardItem == DashboardItem.BrandPieChart;
    }

    public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        return new BrandChartViewModel(DashboardItem, memorabiliaItems);
    }
}
