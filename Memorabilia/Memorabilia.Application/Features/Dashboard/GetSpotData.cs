namespace Memorabilia.Application.Features.Dashboard;

public record GetSpotData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetSpotData, DashboardChartModel>
    {
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetSpotData query)
        {
            var spotIds = _repository.GetSpotIds(query.UserId);
            var spotNames = spotIds.Select(spotId => Constant.Spot.Find(spotId).Name)
                                   .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var spotName in spotNames)
            {
                var spot = Constant.Spot.Find(spotName);
                var count = spotIds.Count(spotId => spotId == spot.Id);

                counts.Add(count);
                labels.Add($"{spotName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
