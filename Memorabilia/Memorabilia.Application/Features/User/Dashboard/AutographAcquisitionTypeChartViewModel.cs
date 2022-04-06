using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class AutographAcquisitionTypeChartViewModel : DashboardItemViewModel
    {
        public AutographAcquisitionTypeChartViewModel() { }

        public AutographAcquisitionTypeChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            DashboardItem = dashboardItem;

            var acquisitions = memorabiliaItems.SelectMany(item => item.Autographs.Where(autograph => autograph.Acquisition != null)
                                                                                  .Select(autograph => autograph.Acquisition));

            var acquisitionTypeNames = acquisitions.Select(acquisition => AcquisitionType.Find(acquisition.AcquisitionTypeId).Name)
                                                   .Distinct();

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
