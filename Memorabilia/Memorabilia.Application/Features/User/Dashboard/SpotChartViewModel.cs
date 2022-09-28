using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class SpotChartViewModel : DashboardItemViewModel
    {
        public SpotChartViewModel() { }

        public SpotChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            DashboardItem = dashboardItem;

            var spotIds = memorabiliaItems.SelectMany(item => item.Autographs.Where(autograph => autograph.Spot?.SpotId > 0).Select(autograph => autograph.Spot.SpotId));
            var spotNames = spotIds.Select(spotId => Spot.Find(spotId).Name).Distinct();

            Labels = spotNames.ToArray();

            var counts = new List<double>();

            foreach (var spotName in spotNames)
            {
                counts.Add(spotIds.Count(spotId => spotId == Spot.Find(spotName).Id));
            }

            DataNew = counts.ToArray();
        }
    }
}
