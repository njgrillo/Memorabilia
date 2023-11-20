namespace Memorabilia.Application.Features.Dashboard;

public record GetSportData() : IQuery<DashboardChartModel>
{
    public class Handler(IMemorabiliaItemRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetSportData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetSportData query)
        {
            int[] sportIds 
                = repository.GetSportIds(applicationStateService.CurrentUser.Id);

            string[] sportNames 
                = sportIds.Select(sportId => Constant.Sport.Find(sportId).Name)
                          .Distinct()
                          .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string sportName in sportNames)
            {
                var sport = Constant.Sport.Find(sportName);
                int count = sportIds.Count(sportId => sportId == sport.Id);

                counts.Add(count);
                labels.Add($"{sportName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
