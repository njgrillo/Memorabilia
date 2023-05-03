namespace Memorabilia.Application.Features.Dashboard;

public record GetSportLeagueLevelData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetSportLeagueLevelData, DashboardChartViewModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetSportLeagueLevelData query)
        {
            var sportLeagueLevelIds = _repository.GetSportLeagueLevelIds(query.UserId);
            var sportLeagueLevelNames = sportLeagueLevelIds.Select(sportLeagueLevelId => Domain.Constants.SportLeagueLevel.Find(sportLeagueLevelId).Name)
                                                           .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var sportLeagueLevelName in sportLeagueLevelNames)
            {
                var sportLeagueLevel = Domain.Constants.SportLeagueLevel.Find(sportLeagueLevelName);
                var count = sportLeagueLevelIds.Count(sportLeagueLevelId => sportLeagueLevelId == sportLeagueLevel.Id);

                counts.Add(count);
                labels.Add($"{sportLeagueLevelName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
