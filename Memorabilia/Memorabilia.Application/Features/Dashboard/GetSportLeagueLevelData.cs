namespace Memorabilia.Application.Features.Dashboard;

public record GetSportLeagueLevelData() : IQuery<DashboardChartModel>
{
    public class Handler(IMemorabiliaItemRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetSportLeagueLevelData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetSportLeagueLevelData query)
        {
            int[] sportLeagueLevelIds 
                = repository.GetSportLeagueLevelIds(applicationStateService.CurrentUser.Id);

            string[] sportLeagueLevelNames 
                = sportLeagueLevelIds.Select(sportLeagueLevelId => Constant.SportLeagueLevel.Find(sportLeagueLevelId).Name)
                                     .Distinct()
                                     .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string sportLeagueLevelName in sportLeagueLevelNames)
            {
                var sportLeagueLevel = Constant.SportLeagueLevel.Find(sportLeagueLevelName);
                int count = sportLeagueLevelIds.Count(sportLeagueLevelId => sportLeagueLevelId == sportLeagueLevel.Id);

                counts.Add(count);
                labels.Add($"{sportLeagueLevelName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
