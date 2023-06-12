namespace Memorabilia.Application.Features.Dashboard;

public record GetSportLeagueLevelData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetSportLeagueLevelData, DashboardChartModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetSportLeagueLevelData query)
        {
            int[] sportLeagueLevelIds = _repository.GetSportLeagueLevelIds(query.UserId);
            string[] sportLeagueLevelNames = sportLeagueLevelIds.Select(sportLeagueLevelId => Constant.SportLeagueLevel.Find(sportLeagueLevelId).Name)
                                                                .Distinct()
                                                                .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string sportLeagueLevelName in sportLeagueLevelNames)
            {
                var sportLeagueLevel = Constant.SportLeagueLevel.Find(sportLeagueLevelName);
                var count = sportLeagueLevelIds.Count(sportLeagueLevelId => sportLeagueLevelId == sportLeagueLevel.Id);

                counts.Add(count);
                labels.Add($"{sportLeagueLevelName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
