using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class WritingInstrumentChartViewModel : DashboardItemViewModel
    {
        public WritingInstrumentChartViewModel() { }

        public WritingInstrumentChartViewModel(DashboardItem dashboardItem, IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            DashboardItem = dashboardItem;

            var writingInstrumentIds = memorabiliaItems.SelectMany(item => item.Autographs.Select(autograph => autograph.WritingInstrumentId));
            var writingInstrumentNames = writingInstrumentIds.Select(writingInstrumentId => WritingInstrument.Find(writingInstrumentId).Name).Distinct();

            Labels = writingInstrumentNames.ToArray();

            var counts = new List<double>();

            foreach (var writingInstrumentName in writingInstrumentNames)
            {
                counts.Add(writingInstrumentIds.Count(writingInstrumentId => writingInstrumentId == WritingInstrument.Find(writingInstrumentName).Id));
            }

            DataNew = counts.ToArray();
        }
    }
}
