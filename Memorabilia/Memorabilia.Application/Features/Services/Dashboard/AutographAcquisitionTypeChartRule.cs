using Memorabilia.Application.Features.User.Dashboard;
using Memorabilia.Domain.Constants;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Services.Dashboard
{
    public class AutographAcquisitionTypeChartRule : DashboardItemRule, IDashboardItemRule
    {
        public override DashboardItem DashboardItem { get; set; }

        public bool Applies(DashboardItem dashboardItem)
        {
            DashboardItem = dashboardItem;

            return dashboardItem == DashboardItem.AutographAcquisitionTypeDonutChart ||
                   dashboardItem == DashboardItem.AutographAcquisitionTypePieChart;
        }

        public DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            return new AutographAcquisitionTypeChartViewModel(DashboardItem, memorabiliaItems);
        }
    }
}
