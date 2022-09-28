using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard
{
    public class MemorabiliaAcquisitionTypeChartRule : DashboardItemRule, IDashboardItemRule
    {
        public override DashboardItem DashboardItem { get; set; }

        public bool Applies(DashboardItem dashboardItem)
        {
            DashboardItem = dashboardItem;

            return dashboardItem == DashboardItem.MemorabiliaAcquisitionTypeDonutChart ||
                   dashboardItem == DashboardItem.MemorabiliaAcquisitionTypePieChart;
        }

        public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            return new MemorabiliaAcquisitionTypeChartViewModel(DashboardItem, memorabiliaItems);
        }
    }
}
