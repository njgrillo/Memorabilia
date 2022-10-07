using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard;

public class EstimatedValuePieChartRule : DashboardItemRule, IDashboardItemRule
{
    public override DashboardItem DashboardItem { get; set; }

    public bool Applies(DashboardItem dashboardItem)
    {
        DashboardItem = dashboardItem;

        return dashboardItem == DashboardItem.EstimatedValueDonutChart ||
               dashboardItem == DashboardItem.EstimatedValuePieChart;
    }

    public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        return new EstimatedValueChartViewModel(DashboardItem, memorabiliaItems);
    }
}
