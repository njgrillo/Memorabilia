using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class MemorabiliaPurchaseTypeChartViewModel : DashboardItemViewModel
    {
        public MemorabiliaPurchaseTypeChartViewModel() { }

        public MemorabiliaPurchaseTypeChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            DashboardItem = dashboardItem;

            var purchaseTypeIds = memorabiliaItems.Where(item => item.Acquisition?.AcquisitionTypeId > 0 && (item.Acquisition?.PurchaseTypeId.HasValue ?? false))
                                                  .Select(item => item.Acquisition.PurchaseTypeId.Value);
            var purchaseTypeNames = purchaseTypeIds.Select(purchaseTypeId => PurchaseType.Find(purchaseTypeId).Name).Distinct();

            Labels = purchaseTypeNames.ToArray();

            var counts = new List<double>();

            foreach (var purchaseTypeName in purchaseTypeNames)
            {
                counts.Add(purchaseTypeIds.Count(purchaseTypeId => purchaseTypeId == PurchaseType.Find(purchaseTypeName).Id));
            }

            DataNew = counts.ToArray();
        }
    }
}
