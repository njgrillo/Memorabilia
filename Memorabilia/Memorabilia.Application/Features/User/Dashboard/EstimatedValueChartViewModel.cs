using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class EstimatedValueChartViewModel : DashboardItemViewModel
    {
        public EstimatedValueChartViewModel() { }

        public EstimatedValueChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            DashboardItem = dashboardItem;

            var memorabiliaEstimatedValueTotal = memorabiliaItems.Sum(memorabiliaItem => memorabiliaItem.EstimatedValue ?? 0);
            var autographsEstimatedValueTotal = memorabiliaItems.Sum(memorabiliaItem => memorabiliaItem.Autographs.Select(autograph => autograph.EstimatedValue ?? 0).Sum());
            
            Labels = new List<string>() { "Memorabilia", "Autographs" }.ToArray();
            DataNew = new List<double>() { (double)memorabiliaEstimatedValueTotal, (double)autographsEstimatedValueTotal }.ToArray();
        }
    }
}
