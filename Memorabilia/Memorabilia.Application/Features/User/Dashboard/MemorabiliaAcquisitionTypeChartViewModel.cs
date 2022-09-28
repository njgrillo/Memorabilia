using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class MemorabiliaAcquisitionTypeChartViewModel : DashboardItemViewModel
    {
        public MemorabiliaAcquisitionTypeChartViewModel() { }

        public MemorabiliaAcquisitionTypeChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            DashboardItem = dashboardItem;

            var acquisitions = memorabiliaItems.Select(item => item.Acquisition);
            var acquisitionTypeNames = acquisitions.Select(acquisition => AcquisitionType.Find(acquisition.AcquisitionTypeId).Name).Distinct();

            Labels = acquisitionTypeNames.ToArray();

            var counts = new List<double>();

            foreach (var acquisitionTypeName in acquisitionTypeNames)
            {
                var acquisitionType = AcquisitionType.Find(acquisitionTypeName);
                var count = acquisitions.Count(acquisition => acquisition.AcquisitionTypeId == acquisitionType.Id);

                counts.Add(count);
            }

            DataNew = counts.ToArray();
        }
    }
}
