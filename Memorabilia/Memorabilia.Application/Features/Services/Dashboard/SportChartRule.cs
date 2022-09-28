using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard
{
    public class SportChartRule : DashboardItemRule, IDashboardItemRule
    {
        public override DashboardItem DashboardItem { get; set; }

        public bool Applies(DashboardItem dashboardItem)
        {
            DashboardItem = dashboardItem;

            return dashboardItem == DashboardItem.SportDonutChart ||
                   dashboardItem == DashboardItem.SportPieChart;
        }

        public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            return new SportChartViewModel(DashboardItem, memorabiliaItems);
        }
    }
}
