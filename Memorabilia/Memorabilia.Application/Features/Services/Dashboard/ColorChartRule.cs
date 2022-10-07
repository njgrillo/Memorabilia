using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard;

public class ColorChartRule : DashboardItemRule, IDashboardItemRule
{
    public override DashboardItem DashboardItem { get; set; }

    public bool Applies(DashboardItem dashboardItem)
    {
        DashboardItem = dashboardItem;

        return dashboardItem == DashboardItem.ColorDonutChart ||
               dashboardItem == DashboardItem.ColorPieChart;
    }

    public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        return new ColorChartViewModel(DashboardItem, memorabiliaItems);
    }
}
