using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard
{
    public class MemorabiliaPurchaseTypeChartRule : DashboardItemRule, IDashboardItemRule
    {
        public override DashboardItem DashboardItem { get; set; }

        public bool Applies(DashboardItem dashboardItem)
        {
            DashboardItem = dashboardItem;

            return dashboardItem == DashboardItem.MemorabiliaPurchaseTypeDonutChart ||
                   dashboardItem == DashboardItem.MemorabiliaPurchaseTypePieChart;
        }

        public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            return new MemorabiliaPurchaseTypeChartViewModel(DashboardItem, memorabiliaItems);
        }
    }
}
