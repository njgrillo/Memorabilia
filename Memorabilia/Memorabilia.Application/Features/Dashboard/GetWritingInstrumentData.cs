namespace Memorabilia.Application.Features.Dashboard;

public record GetWritingInstrumentData() : IQuery<DashboardChartModel>
{
    public class Handler(IAutographRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetWritingInstrumentData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetWritingInstrumentData query)
        {
            int[] writingInstrumentIds 
                = repository.GetWritingInstrumentIds(applicationStateService.CurrentUser.Id);

            string[] writingInstrumentNames 
                = writingInstrumentIds.Select(writingInstrumentId => Constant.WritingInstrument.Find(writingInstrumentId).Name)
                                      .Distinct()
                                      .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string writingInstrumentName in writingInstrumentNames)
            {
                var writingInstrument = Constant.WritingInstrument.Find(writingInstrumentName);
                var count = writingInstrumentIds.Count(writingInstrumentId => writingInstrumentId == writingInstrument.Id);

                counts.Add(count);
                labels.Add($"{writingInstrumentName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
