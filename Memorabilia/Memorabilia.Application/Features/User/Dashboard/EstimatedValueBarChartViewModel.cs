using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class EstimatedValueBarChartViewModel : DashboardItemViewModel
    {
        public EstimatedValueBarChartViewModel() { }

        public EstimatedValueBarChartViewModel(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            DashboardItem = DashboardItem.EstimatedValueBarChart;

            var memorabiliaEstimatedValueTotal = memorabiliaItems.Sum(memorabiliaItem => memorabiliaItem.EstimatedValue ?? 0);
            var autographsEstimatedValueTotal = memorabiliaItems.Sum(memorabiliaItem => memorabiliaItem.Autographs.Select(autograph => autograph.EstimatedValue ?? 0).Sum());
            var totalEstimatedValue = memorabiliaEstimatedValueTotal + autographsEstimatedValueTotal;
            var data = new List<List<object>>();
            var objectList = new List<object>();

            objectList = new List<object>();
            objectList.Add(string.Empty);
            objectList.Add("Dollar Amount ($)");

            data.Add(objectList);

            objectList = new List<object>();
            objectList.Add("Memorabilia");
            objectList.Add(memorabiliaEstimatedValueTotal);

            data.Add(objectList);

            objectList = new List<object>();
            objectList.Add("Autographs");
            objectList.Add(autographsEstimatedValueTotal);

            data.Add(objectList);

            objectList = new List<object>();
            objectList.Add("Total");
            objectList.Add(totalEstimatedValue);

            data.Add(objectList);

            Data = data;
        }
    }
}
