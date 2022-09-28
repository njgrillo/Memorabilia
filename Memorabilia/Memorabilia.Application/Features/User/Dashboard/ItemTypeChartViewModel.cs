using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class ItemTypeChartViewModel : DashboardItemViewModel
    {
        public ItemTypeChartViewModel() { }

        public ItemTypeChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            DashboardItem = dashboardItem;

            var itemTypes = memorabiliaItems.Select(item => item.ItemType);
            var distinctItemTypeNames = itemTypes.Select(itemType => itemType.Name).Distinct();

            Labels = distinctItemTypeNames.ToArray();

            var counts = new List<double>();

            foreach (var itemTypeName in distinctItemTypeNames)
            {
                counts.Add(itemTypes.Count(itemType => itemType.Name == itemTypeName));
            }

            DataNew = counts.ToArray();
        }
    }
}
