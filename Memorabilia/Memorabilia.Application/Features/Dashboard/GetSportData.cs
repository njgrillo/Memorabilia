namespace Memorabilia.Application.Features.Dashboard;

public record GetSportData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetSportData, DashboardChartModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetSportData query)
        {
            int[] sportIds = _repository.GetSportIds(query.UserId);
            string[] sportNames = sportIds.Select(sportId => Constant.Sport.Find(sportId).Name)
                                          .Distinct()
                                          .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string sportName in sportNames)
            {
                var sport = Constant.Sport.Find(sportName);
                var count = sportIds.Count(sportId => sportId == sport.Id);

                counts.Add(count);
                labels.Add($"{sportName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
