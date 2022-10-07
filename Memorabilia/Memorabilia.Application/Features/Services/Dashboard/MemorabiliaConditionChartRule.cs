using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard;

public class MemorabiliaConditionChartRule : DashboardItemRule, IDashboardItemRule
{
    public override DashboardItem DashboardItem { get; set; }

    public bool Applies(DashboardItem dashboardItem)
    {
        DashboardItem = dashboardItem;

        return dashboardItem == DashboardItem.MemorabiliaConditionDonutChart ||
               dashboardItem == DashboardItem.MemorabiliaConditionPieChart;
    }

    public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
    {
        return new MemorabiliaConditionChartViewModel(DashboardItem, memorabiliaItems);
    }
}
