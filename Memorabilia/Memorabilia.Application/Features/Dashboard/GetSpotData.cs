namespace Memorabilia.Application.Features.Dashboard;

public record GetSpotData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetSpotData, DashboardChartViewModel>
    {
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetSpotData query)
        {
            var spotIds = _repository.GetSpotIds(query.UserId);
            var spotNames = spotIds.Select(spotId => Domain.Constants.Spot.Find(spotId).Name)
                                   .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var spotName in spotNames)
            {
                var spot = Domain.Constants.Spot.Find(spotName);
                var count = spotIds.Count(spotId => spotId == spot.Id);

                counts.Add(count);
                labels.Add($"{spotName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
