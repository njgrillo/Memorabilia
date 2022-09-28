using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class SportChartViewModel : DashboardItemViewModel
    {
        public SportChartViewModel() { }

        public SportChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            DashboardItem = dashboardItem;

            var sports = memorabiliaItems.SelectMany(item => item.Sports);
            var sportNames = sports.Select(sport => sport.Sport.Name).Distinct();

            Labels = sportNames.ToArray();

            var counts = new List<double>();

            foreach (var sportName in sportNames)
            {
                counts.Add(sports.Count(sport => sport.Sport.Name == sportName));
            }

            DataNew = counts.ToArray();
        }
    }
}
