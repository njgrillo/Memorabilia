using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class ColorChartViewModel : DashboardItemViewModel
    {
        public ColorChartViewModel() { }

        public ColorChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            DashboardItem = dashboardItem;

            var colorIds = memorabiliaItems.SelectMany(item => item.Autographs.Select(autograph => autograph.ColorId));
            var colorNames = colorIds.Select(colorId => Color.Find(colorId).Name).Distinct();

            Labels = colorNames.ToArray();

            var counts = new List<double>();

            foreach (var colorName in colorNames)
            {
                counts.Add(colorIds.Count(colorId => colorId == Color.Find(colorName).Id));
            }

            DataNew = counts.ToArray();
        }
    }
}
